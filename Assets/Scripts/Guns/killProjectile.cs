using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killProjectile : MonoBehaviour
{
    public Transform player;
    public GameObject fireExplosion;
    public GameObject snowExplosion;
    private float distance;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (gameObject.name == "Projectile(Clone)")
        {
            GameObject explosion = GameObject.Instantiate(fireExplosion, transform.position, transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(gameObject);
        }
        if (gameObject.name == "blizzard Projectile(Clone)")
        {
            GameObject explosion = GameObject.Instantiate(snowExplosion, transform.position, transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(gameObject);
        }

    }
     void distanceToPlayer()
    {
        distance = Mathf.Sqrt(Mathf.Pow(player.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow(player.localPosition.y - transform.localPosition.y, 2) + Mathf.Pow(player.localPosition.z - transform.localPosition.z, 2));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer();
        if(distance > 100)
        {
            Destroy(gameObject);
        }
    }
}
