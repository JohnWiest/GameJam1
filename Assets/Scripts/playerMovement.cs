using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerPhysics;
    public Transform player;
    public Transform camera;
    public float step = 0.1f;
    public float mouseSensitivity = 1f;
    public float gravity;
    private float velX, velY, velZ, rX, rY, rZ;
    private float floorheight = 0f;



    private bool[] directionPressed = new bool[6];

    private void moveCameraWASD(Transform point)
    {
        if (directionPressed[0])
        {
            point.localPosition += new Vector3(step * Mathf.Sin(D2R(rY)), 0f, step * Mathf.Cos(D2R(rY)));
        }
        if (directionPressed[1])
        {
            point.localPosition -= new Vector3(step * Mathf.Sin(D2R(rY)), 0f, step * Mathf.Cos(D2R(rY)));
        }
        if (directionPressed[2])
        {
            point.localPosition -= new Vector3(step * Mathf.Cos(D2R(180f - rY)), 0f, step * Mathf.Sin(D2R(180f - rY)));
        }
        if (directionPressed[3])
        {
            point.localPosition += new Vector3(step * Mathf.Cos(D2R(180f - rY)), 0f, step * Mathf.Sin(D2R(180f - rY)));
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
        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");
        point.localRotation = Quaternion.Euler(rX - mouseSensitivity * mouseYValue, rY + mouseSensitivity * mouseXValue, 0f);
        rX = camera.transform.rotation.eulerAngles.x;
        rY = camera.transform.rotation.eulerAngles.y;

        if (180.0f > rX && rX > 89.0f)
        {
            camera.localRotation = Quaternion.Euler(89.0f, camera.transform.rotation.eulerAngles.y, 0f);
        }
        else if (180.0f < rX && rX < 275.0f)
        {
            camera.localRotation = Quaternion.Euler(275.0f, camera.transform.rotation.eulerAngles.y, 0f);
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

    private void playerCameraPhysics()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerPhysics.AddForce(new Vector3(0f, 20f, 0f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rX = camera.transform.rotation.eulerAngles.x;
        rY = camera.transform.rotation.eulerAngles.y;
        rZ = camera.transform.rotation.eulerAngles.z;
        lockMouse();
        checkDirectionPressed(directionPressed);
        moveCameraWASD(player);
        rotateCamera(camera);
        playerCameraPhysics();
    }
}
