using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRifle : MonoBehaviour
{
    public Transform player;
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;
    public AudioClip shootNoise;
    public AudioClip reloadNoise;
    AudioSource audioSource;
    private float timeSinceLastShot;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeSinceLastShot = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (Input.GetKeyDown(shootKey) && timeSinceLastShot>=2)
        {
            timeSinceLastShot = 0;
            audioSource.PlayOneShot(shootNoise);
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            shot.GetComponent<killProjectile>().player = player;
            shot.GetComponent<killProjectile>().self = shot.GetComponent<Transform>();
            StartCoroutine(playSoundAfter1Seconds());
        }
    }
    IEnumerator playSoundAfter1Seconds()
    {
        yield return new WaitForSeconds(1.4f);
        audioSource.PlayOneShot(reloadNoise);
    }
}
