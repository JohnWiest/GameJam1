using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blizzardEvents : MonoBehaviour
{
    public Transform player;
    public GameObject projectile;
    public float moveSpeed = 1f;
    public float shootForce;
    public GameObject particleEffect;
    public int health;
    private int damage;

    private Vector3 playerDirection;
    private Vector3 move;
    private float distanceFromPlayer;
    private System.Random r = new System.Random(2);
    private float prevShotTime = 0f;
    private killProjectile projectileScript;
    private int numMoves = 0;
    private float moveTime = 0;
    private bool moveTowardPlayer = false;
    private bool moveAwayPlayer = false;


    void calculateDirDist2Player()
    {
        playerDirection = new Vector3(player.localPosition.x - transform.localPosition.x, player.localPosition.y - transform.localPosition.y, player.localPosition.z - transform.localPosition.z).normalized;
        distanceFromPlayer = Mathf.Sqrt(Mathf.Pow(player.localPosition.x - transform.localPosition.x, 2f) + Mathf.Pow(player.localPosition.y - transform.localPosition.y, 2f) + Mathf.Pow(player.localPosition.z - transform.localPosition.z, 2f));
    }

    void moveEntity()
    {
        float dT = Time.deltaTime;

        if (distanceFromPlayer > 45 && numMoves == 3 && !moveTowardPlayer)
        {
            Debug.Log("moving Toward Player");
            numMoves = 0;
            moveTowardPlayer = true;
            move = Vector3.Scale(playerDirection, new Vector3(moveSpeed * dT, moveSpeed * dT, moveSpeed * dT)).normalized;
        }
        else if (distanceFromPlayer < 45 && numMoves == 3 && !moveAwayPlayer)
        {
            Debug.Log("moving Away Player");
            numMoves = 0;
            moveAwayPlayer = true;
            move = Vector3.Scale(playerDirection, new Vector3(-moveSpeed * dT, -moveSpeed * dT, -moveSpeed * dT)).normalized;
        }
        else if ((distanceFromPlayer > 45 && moveAwayPlayer) | (distanceFromPlayer < 45 && moveTowardPlayer))
        {
            Debug.Log("moves reset");
            moveTowardPlayer = false;
            moveAwayPlayer = false;
        }
        else if (!moveTowardPlayer && !moveAwayPlayer && numMoves < 3 && moveTime == 0)
        {
            Debug.Log("Choosing new move direction");
            move = new Vector3((float)r.Next(-10, 10), (float)r.Next(1, 10), (float)r.Next(-10, 10)).normalized;
            moveTime = 0.01f;
        }
        else if (!moveTowardPlayer && !moveAwayPlayer && numMoves < 3 && moveTime >= 2f)
        {
            Debug.Log("Choosing new move direction");
            moveTime = 0f;
            numMoves += 1;
        }
        else
        {
            //Debug.Log("moving");
            moveTime += Time.deltaTime;
        }
        GetComponent<Rigidbody>().MovePosition(transform.localPosition + Vector3.Scale(move, new Vector3(moveSpeed * dT, moveSpeed * dT, moveSpeed * dT)));

    }

    void rotateEntity()
    {
        float angle = (Mathf.Asin((player.localPosition.x - transform.localPosition.x) / distanceFromPlayer) * 180f / Mathf.PI);
        float dX = player.localPosition.x - transform.localPosition.x;
        float dZ = player.localPosition.z - transform.localPosition.z;
        if (angle < 0)
        {
            if (dZ < 0)
            {
                angle = angle + 270f;
            }
            else
            {
                angle = 90f - angle;
            }

        }
        else
        {
            if (dZ < 0)
            {
                angle = angle + 270f;
            }
            else
            {
                angle = 90f - angle;
            }

        }
        transform.localRotation = Quaternion.Euler(0f, -angle - 90, 0f);
    }

    void shootPlayer()
    {
        prevShotTime += Time.deltaTime;
        if (prevShotTime >= 3)
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.localPosition + new Vector3(0f,1f, 0f), transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(playerDirection * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            projectileScript = shot.GetComponent<killProjectile>();
            projectileScript.player = player;
            Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
            prevShotTime = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            damage = Random.Range(20, 45);
            FloatingTextControler.CreateFloatingText(damage.ToString(), gameObject.transform);
            health -= damage;
        }
        else if (collision.gameObject.name == "Lazer Projectile(Clone)")
        {

            damage = Random.Range(70, 130);
            FloatingTextControler.CreateFloatingText(damage.ToString(), gameObject.transform);
            health -= damage;
        }
    }

    void Start()
    {
        FloatingTextControler.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        calculateDirDist2Player();
        moveEntity();
        rotateEntity();
        shootPlayer();
        if (health <= 0)
        {
            Global.count++;
            GameObject explosion = GameObject.Instantiate(particleEffect, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(gameObject);
        }
    }
}
