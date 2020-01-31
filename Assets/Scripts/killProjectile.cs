using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killProjectile : MonoBehaviour
{
    public Transform player;
    public Transform self;
    public GameObject particleEffect;
    private float distance;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Projectile(Clone)")
        {
            GameObject explosion = GameObject.Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(gameObject);
        }
    }
     void distanceToPlayer()
    {
        distance = Mathf.Sqrt(Mathf.Pow(player.localPosition.x - self.localPosition.x, 2) + Mathf.Pow(player.localPosition.y - self.localPosition.y, 2) + Mathf.Pow(player.localPosition.z - self.localPosition.z, 2));
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
