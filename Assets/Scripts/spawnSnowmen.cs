using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSnowmen : MonoBehaviour
{
    public Transform Player;
    public GameObject snowman;

    private System.Random r = new System.Random();
    private moveToPlayer movementScript;
    int i = 0;

    private GameObject[] snowmen = new GameObject[1];
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 1; i++)
        {
            if (!snowmen[i])
            { 
                snowmen[i] = GameObject.Instantiate(snowman, new Vector3((float)r.Next(-54, 54), 2f, (float)r.Next(-10, 54)), transform.rotation);
                movementScript = snowmen[i].GetComponent<moveToPlayer>();
                movementScript.player = Player;
            }
        }
    }
}
