using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Rigidbody playerPhysics;
    public Transform player;
    public Transform camera;
    public float step = 0.1f;
    public float sensitivity = 1f;
    public float floorheight = 0f;

    private bool[] directionPressed = new bool[6];

    private void moveCameraWASD(Transform point)
    {
        float Ry = camera.transform.rotation.eulerAngles.y;
        if (directionPressed[0])
        {
            point.localPosition += new Vector3(step * Mathf.Sin(D2R(Ry)), 0f, step * Mathf.Cos(D2R(Ry)));
        }
        if (directionPressed[1])
        {
            point.localPosition -= new Vector3(step * Mathf.Sin(D2R(Ry)), 0f, step * Mathf.Cos(D2R(Ry)));
        }
        if (directionPressed[2])
        {
            point.localPosition -= new Vector3(step * Mathf.Cos(D2R(180f - Ry)), 0f, step * Mathf.Sin(D2R(180f - Ry)));
        }
        if (directionPressed[3])
        {
            point.localPosition += new Vector3(step * Mathf.Cos(D2R(180f - Ry)), 0f, step * Mathf.Sin(D2R(180f - Ry)));
        }
    }

    private void checkDirectionPressed(bool[] directionPressed)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            directionPressed[0] = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            directionPressed[0] = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            directionPressed[1] = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            directionPressed[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            directionPressed[2] = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            directionPressed[2] = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionPressed[3] = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            directionPressed[3] = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            directionPressed[4] = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            directionPressed[4] = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            directionPressed[5] = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            directionPressed[5] = false;
        }
    }

    private void rotateCamera(Transform point)
    {
        float Rx = point.transform.rotation.eulerAngles.x;
        float Ry = point.transform.rotation.eulerAngles.y;
        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");
        point.localRotation = Quaternion.Euler(Rx - sensitivity * mouseYValue, Ry + sensitivity * mouseXValue, 0f);
        Rx = point.transform.rotation.eulerAngles.x;

        if (180.0f > Rx && Rx > 89.0f)
        {
            point.localRotation = Quaternion.Euler(89.0f, point.transform.rotation.eulerAngles.y, 0f);
        }
        else if (180.0f < Rx && Rx < 275.0f)
        {
            point.localRotation = Quaternion.Euler(275.0f, point.transform.rotation.eulerAngles.y, 0f);
        }


    }

    private void lockMouse()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private float D2R(float degrees)
    {
        return Mathf.PI * degrees / 180.0f;
    }

    private void playerCameraPhysics(Rigidbody body)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }



    // Update is called once per frame
    void Update()
    {
        lockMouse();
        checkDirectionPressed(directionPressed);
        moveCameraWASD(player);
        rotateCamera(camera);
        playerCameraPhysics(playerPhysics);
    }
}
