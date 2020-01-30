using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blizzardMovement : MonoBehaviour
{
    public Transform entity;
    public Transform player;
    public Rigidbody body;
    public float moveSpeed = 1f;

    private Vector3 playerDirection;
    private Vector3 move;
    private float distanceFromPlayer;
    private System.Random r = new System.Random(2);

    

    void calculateDirDist2Player()
    {
        playerDirection = new Vector3(player.localPosition.x - entity.localPosition.x, player.localPosition.y - entity.localPosition.y, player.localPosition.z - entity.localPosition.z).normalized;
        distanceFromPlayer = Mathf.Sqrt(Mathf.Pow(player.localPosition.x - entity.localPosition.x, 2f) + Mathf.Pow(player.localPosition.y - entity.localPosition.y, 2f) + Mathf.Pow(player.localPosition.z - entity.localPosition.z, 2f));
    }

    void moveEntity()
    {
        float dT = Time.deltaTime;
        
        if (distanceFromPlayer > 45)
        {
            move = (move + Vector3.Scale(playerDirection, new Vector3(moveSpeed * dT, moveSpeed * dT, moveSpeed * dT))).normalized;
        }
        else if (distanceFromPlayer < 15)
        {
            move = (move - Vector3.Scale(playerDirection, new Vector3(moveSpeed * dT, moveSpeed * dT, moveSpeed * dT))).normalized;
        }
        body.MovePosition(entity.localPosition + Vector3.Scale(move, new Vector3 (moveSpeed * dT, moveSpeed * dT, moveSpeed * dT)));
        
    }

    void rotateEntity()
    {
        float angle = (Mathf.Asin((player.localPosition.x - entity.localPosition.x) / distanceFromPlayer) * 180f / Mathf.PI);
        float dX = player.localPosition.x - entity.localPosition.x;
        float dZ = player.localPosition.z - entity.localPosition.z;
        if (angle < 0)
        {
            if (dZ < 0)
            {
                angle = angle + 270f;
            }
            else
            {
                angle = 90f - angle;
            }

        }
        else
        {
            if (dZ < 0)
            {
                angle = angle + 270f;
            }
            else
            {
                angle = 90f - angle;
            }

        }
        entity.localRotation = Quaternion.Euler(0f, -angle - 90, 0f);
    }

    void Start()
    {
        move = new Vector3((float)r.Next(0, 100), (float)r.Next(0, 100), (float)r.Next(0, 100)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        calculateDirDist2Player();
        moveEntity();
        rotateEntity();
    }
}
