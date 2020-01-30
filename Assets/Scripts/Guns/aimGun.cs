using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimGun : MonoBehaviour
{
    private Transform gun;
    public Weapons currentWeapon;
    private bool aimed = false;

    private void Start()
    {
        gun = currentWeapon.weapons[currentWeapon.currentWeapon].transform;
    }
    // Update is called once per frame
    void Update()
    {
        gun = currentWeapon.weapons[currentWeapon.currentWeapon].transform;
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
