using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimGun : MonoBehaviour
{
    public Transform gun;
    
    private bool aimed = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && aimed == false)
        {
            gun.localPosition += new Vector3(-0.4f, 0.15f, 0f);
            aimed = true;
        }
        else if (!Input.GetKey(KeyCode.Mouse1) && aimed == true)
        {
            gun.localPosition -= new Vector3(-0.4f, 0.15f, 0f);
            aimed = false;
        }
    }
}
