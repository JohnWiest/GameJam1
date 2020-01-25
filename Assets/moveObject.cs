using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public Transform pointPrefab;

    private bool[] directionPressed = new bool[4];

    private void moveCamera (Transform point)
    {
        if (directionPressed[0])
        {
            point.localPosition = Vector3.forward;
        }
        if (directionPressed[1])
        {
            point.localPosition = Vector3.back;
        }
        if (directionPressed[2])
        {
            point.localPosition = Vector3.right;
        }
        if (directionPressed[3])
        {
            point.localPosition = Vector3.left;
        }
    } 
    
    private void checkDirectionPressed(bool[] directionPressed)
    {
        if (Input.GetKeyDown(KeyCode.w))
        {
            directionPressed[0] = true;
        }
        else if (Input.GetKeyUp(KeyCode.w))
        {
            directionPressed[0] = false;
        }
        if (Input.GetKeyDown(KeyCode.s)
        {
            directionPressed[1] = true;
        }
        else if (Input.GetKeyUp(KeyCode.s)
        {
            directionPressed[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.d))
        {
            directionPressed[2] = true;
        }
        else if (Input.GetKeyUp(KeyCode.d))
        {
            directionPressed[2] = false;
        }
        if (Input.GetKeyDown(KeyCode.a))
        {
            directionPressed[3] = true;
        }
        else if (Input.GetKeyUp(KeyCode.a))
        {
            directionPressed[3] = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform point = Instantiate(pointPrefab);
        checkDirectionPressed(directionPressed);
        moveCamera(point);
    }
}
