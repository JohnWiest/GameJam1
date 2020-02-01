using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEvents : MonoBehaviour
{
    public Rigidbody playerPhysics;
    public Transform player;
    public Transform camera;
    [Range(10f, 100f)]
    public float moveSpeed = 1f; //units per second
    [Range(1.0f, 10.0f)]
    public float mouseSensitivity = 1f;
    [Range(100f, 1000f)]
    public float jumpForce = 50f;
    public float fallScaler = 2.5f;
    public float lowJumpScaler = 2f;
    private float rX, rY, rZ;
    private bool onGround = false;
    public static int health = 100;



    private bool[] directionPressed = new bool[6];

    private void movePlayer(Rigidbody body)
    {
        float dT = Time.deltaTime;
        float yaw = D2R(rY);
        float cosYaw = Mathf.Cos(yaw);
        float sinYaw = Mathf.Sin(yaw);

        Vector3 movedirection = new Vector3(0f, 0f, 0f);
        Vector3 move = new Vector3(0f, 0f, 0f);
        Vector3 speed = new Vector3(moveSpeed * dT, 0f, moveSpeed * dT);

        if (directionPressed[0])
        {
            movedirection += new Vector3(sinYaw, 0f, cosYaw);
        }
        if (directionPressed[1])
        {
            movedirection -= new Vector3(sinYaw, 0f, cosYaw);
        }
        if (directionPressed[2])
        {
            movedirection += new Vector3(cosYaw, 0f, -1f * sinYaw);
        }
        if (directionPressed[3])
        {
            movedirection -= new Vector3(cosYaw, 0f, -1f * sinYaw);
        }
        movedirection = movedirection.normalized;
        body.MovePosition(player.localPosition + Vector3.Scale(movedirection, speed));
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

    private void playerJump(Rigidbody body)
    {

        if (Input.GetKey(KeyCode.Space) && onGround == true)
        {
            playerPhysics.AddForce(new Vector3(0f, jumpForce, 0f));
            onGround = false;
        }
        if (body.velocity.y < 0)
        {
            body.velocity += Vector3.up * Physics.gravity.y * (fallScaler - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ground")
        {
            onGround = true;
        }if (collision.gameObject.name == "Snowman1- c(Clone)")
        {
            health -= 10;
        }if (collision.gameObject.name == "blizzard Projectile(Clone)")
        {
            health -= 20;
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
        // Debug.Log(1f / Time.deltaTime);
        rX = camera.transform.rotation.eulerAngles.x;
        rY = camera.transform.rotation.eulerAngles.y;
        rZ = camera.transform.rotation.eulerAngles.z;
        lockMouse();
        checkDirectionPressed(directionPressed);
        rotateCamera(camera);
        movePlayer(playerPhysics);
        playerJump(playerPhysics);
    }
}
