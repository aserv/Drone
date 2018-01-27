using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInZone : MonoBehaviour
{

    //Pass in reference to player object to make it slightly faster (compared to scanning)
    public GameObject player;
    //The distance allowed to command from
    public float allowedCommandDistance;
    //The location of the object treated as the "switch"
    private Vector3 switchLocation;

    // Use this for initialization
    void Start()
    {
        switchLocation = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player)
        {
            if (Input.GetButtonDown("Command"))
            {
                Vector3 playerLocation = Player.gameObject.transform.position;
                float distance = Vector3.Distance(playerLocation, switchLocation);
                if (distance <= allowedCommandDistance)
                {
                    Debug.Log("trigged");
                }
            }
        }
    }
}
