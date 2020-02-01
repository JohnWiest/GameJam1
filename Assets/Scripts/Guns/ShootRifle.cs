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
    private float coolDown;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        chargingTime = 0;
        charged = false;
        chargeStarted = false;
        coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetKey(shootKey) && coolDown<=0)
        {
            chargingTime += Time.deltaTime;
            if(chargeStarted == false)
            {
                chargeStarted = true;
                audioSource.clip = chargingNoise;
                audioSource.Play();
            }
            if (chargingTime >= 2)
            {
                charged = true;
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
            coolDown = 2f;
            audioSource.Stop();
            audioSource.clip = shootNoise;
            audioSource.Play();
            chargingTime = 0;
            chargeStarted = false;
            charged = false;
            GameObject shot = GameObject.Instantiate(projectile, transform.position + new Vector3(0f,0f,0f), transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            shot.GetComponent<killProjectile>().player = player;
            StartCoroutine(playSoundAfterOneSeconds());
        }
    }
    IEnumerator playSoundAfterOneSeconds()
    {
        Debug.Log(1);
        yield return new WaitForSeconds(1.4f);
        audioSource.clip = delayNoise;
        audioSource.Play();
    }

    // then elsewhere when you want to invoke it:
}
