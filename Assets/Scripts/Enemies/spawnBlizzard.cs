using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlizzard : MonoBehaviour
{
    public Transform Player;
    public GameObject blizzard;

    private System.Random r = new System.Random(23);
    private blizzardEvents entityEvents;

    private GameObject[] blizzards = new GameObject[1];
    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 1; i++)
        {
            if (!blizzards[i])
            {
                blizzards[i] = GameObject.Instantiate(blizzard, new Vector3((float)r.Next(-54, 54), 2f, (float)r.Next(-10, 54)), transform.rotation);
                entityEvents = blizzards[i].GetComponent<blizzardEvents>();
                entityEvents.player = Player;
            }
        }
    }
}
