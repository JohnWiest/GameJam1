using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    public Transform pointPrefab;

    private bool[] directionPressed = new bool[4];

    private void moveObject(Transform point)
    {
        float step = 0.1f;
        if (directionPressed[0])
        {
            point.localPosition += Vector3.forward * step;
        }
        if (directionPressed[1])
        {
            point.localPosition += Vector3.back * step;
        }
        if (directionPressed[2])
        {
            point.localPosition += Vector3.right * step;
        }
        if (directionPressed[3])
        {
            point.localPosition += Vector3.left * step;
        }

    }

    private void checkDirectionPressed(bool[] directionPressed)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            directionPressed[0] = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            directionPressed[0] = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            directionPressed[1] = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            directionPressed[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionPressed[2] = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            directionPressed[2] = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionPressed[3] = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
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
        
        checkDirectionPressed(directionPressed);
        moveObject(pointPrefab);
    }
}