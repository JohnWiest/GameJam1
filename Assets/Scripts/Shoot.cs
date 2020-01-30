﻿using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class Shoot : MonoBehaviour
 {
    public Transform player;
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;



// Use this for initialization
    void Start ()
    {

    }

// Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            shot.GetComponent<Rigidbody>().useGravity = false;
            shot.GetComponent<killProjectile>().player = player;
            shot.GetComponent<killProjectile>().self = shot.GetComponent<Transform>();
        }
    }
 }