using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanDeath : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject deathSoundHolder;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            Debug.Log(health);
            health -= 1;
            Debug.Log(health);
        }
        else if(collision.gameObject.name == "Rifle Projectile(Clone)")
        {
   
            health -= 2;
        }
        if (health == 0)
        {
            GameObject soundEffect = GameObject.Instantiate(deathSoundHolder, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Destroy(soundEffect, 2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Global.count++;
            GameObject explosion = GameObject.Instantiate(particleEffect, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Destroy(explosion, 2.0f);
            Destroy(gameObject);
        }
    }
}
