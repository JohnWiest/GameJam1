using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimGun : MonoBehaviour
{
    [Range(0f,100f)]
    public float zoomFov;
    public Weapons currentWeapon;

    private float normalFov = 60;
    private bool aimed = false;
    private Transform gun;

    private void Start()
    {
        Debug.Log(Camera.current.fieldOfView);
        gun = currentWeapon.weapons[currentWeapon.currentWeapon].transform;
    }
    // Update is called once per frame
    void Update()
    {
        gun = currentWeapon.weapons[currentWeapon.currentWeapon].transform;
        if (Input.GetKey(KeyCode.Mouse1) && aimed == false && currentWeapon.currentWeapon == 0)
        {
            gun.localPosition += new Vector3(-0.4f, 0.15f, 0f);
            aimed = true;
        }
        else if (!Input.GetKey(KeyCode.Mouse1) && aimed == true && currentWeapon.currentWeapon == 0)
        {
            gun.localPosition -= new Vector3(-0.4f, 0.15f, 0f);
            aimed = false;
        }
        else if (Input.GetKey(KeyCode.Mouse1) && aimed == false && currentWeapon.currentWeapon == 1)
        {
            Camera.current.fieldOfView = zoomFov;
            gun.localPosition += new Vector3(-0.4f, 0.15f, 0f);
            aimed = true;
        }
        else if (!Input.GetKey(KeyCode.Mouse1) && aimed == true && currentWeapon.currentWeapon == 1)
        {
            Camera.current.fieldOfView = normalFov;
            gun.localPosition -= new Vector3(-0.4f, 0.15f, 0f);
            aimed = false;
        }
    }
}
