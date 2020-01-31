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
    public AudioClip delayNoise;
    public AudioClip chargingNoise;
    AudioSource audioSource;
    private float chargingTime;
    private bool charged;
    private bool chargeStarted;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        chargingTime = 0;
        charged = false;
        chargeStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shootKey))
        {
            chargingTime += Time.deltaTime;
            Debug.Log(chargingTime);
            if(chargeStarted == false)
            {
                chargeStarted = true;
                audioSource.clip = chargingNoise;
                audioSource.Play();
            }
            if (chargingTime >= 2)
            {
                charged = true;
                Debug.Log(charged);
            }
        }
        else
        {
            if(chargingTime > 0)
            {
                audioSource.Stop();
            }
            chargingTime = 0;
            chargeStarted = false;
        }
        if (charged && !(Input.GetKey(shootKey)))
        {
            audioSource.Stop();
            audioSource.clip = shootNoise;
            audioSource.Play();
            chargingTime = 0;
            chargeStarted = false;
            charged = false;
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            shot.GetComponent<killProjectile>().player = player;
            shot.GetComponent<killProjectile>().self = shot.GetComponent<Transform>();
            StartCoroutine(playSoundAfterOneSeconds());
        }
    }
    IEnumerator playSoundAfterOneSeconds()
    {
        yield return new WaitForSeconds(1.4f);
        audioSource.clip = delayNoise;
        audioSource.Play();
    }

    // then elsewhere when you want to invoke it:
}
