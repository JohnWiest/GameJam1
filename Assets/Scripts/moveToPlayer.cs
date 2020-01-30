using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayer : MonoBehaviour
{
    public Transform entity;
    public Transform player;
    public Rigidbody body;
    public float moveSpeed = 1f;

    private Vector3 playerDirection;
    private float distanceFromPlayer;

    void calculateDirDist2Player()
    {
        playerDirection = new Vector3(player.localPosition.x - entity.localPosition.x, 0f, player.localPosition.z - entity.localPosition.z).normalized;
        distanceFromPlayer = Mathf.Sqrt(Mathf.Pow(player.localPosition.x - entity.localPosition.x, 2f) + Mathf.Pow(player.localPosition.z - entity.localPosition.z, 2f));
    }

    void moveEntity()
    {
        float dT = Time.deltaTime;
        if (distanceFromPlayer > 4)
        {
            body.MovePosition(entity.localPosition + Vector3.Scale(playerDirection, new Vector3(moveSpeed * dT, moveSpeed * dT, moveSpeed * dT)));
        }
    }

    void rotateEntity()
    {
        float angle = (Mathf.Asin((player.localPosition.x - entity.localPosition.x) / distanceFromPlayer) * 180f / Mathf.PI);
        float dX = player.localPosition.x - entity.localPosition.x;
        float dZ = player.localPosition.z - entity.localPosition.z;
        if (angle < 0)
        {
            if(dZ < 0)
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
            if(dZ < 0)
            {
                angle = angle + 270f;
            }
            else
            {
                angle = 90f - angle;
            }

        }
        entity.localRotation = Quaternion.Euler(0f, -angle - 180, 0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        calculateDirDist2Player();
        moveEntity();
        rotateEntity();
    }
}
