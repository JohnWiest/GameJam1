using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanDeath : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject deathSoundHolder;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            health -= 1;
            if (health == 0)
            {
                GameObject soundEffect = GameObject.Instantiate(deathSoundHolder, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Global.count++;
            GameObject explosion = GameObject.Instantiate(particleEffect, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Destroy(gameObject);
        }
    }
}
