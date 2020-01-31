using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class Shoot : MonoBehaviour
 {
    public Transform player;
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;
    public AudioClip shootNoise;
    AudioSource audioSource;


// Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

// Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(shootKey))
        {
            audioSource.PlayOneShot(shootNoise);
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            shot.GetComponent<killProjectile>().player = player;
            shot.GetComponent<killProjectile>().self = shot.GetComponent<Transform>();
        }
    }
}