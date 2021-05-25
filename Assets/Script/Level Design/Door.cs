using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform teleportPoint;

     public Transform player;

     bool isTeleportTrigger;


    private void Update()
    {
        if (isTeleportTrigger == true && Input.GetButtonDown("Interact"))
        {
            player.position = teleportPoint.position;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
            isTeleportTrigger = true;
            Debug.Log(isTeleportTrigger);
         
            }

        }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTeleportTrigger = false;
            Debug.Log(isTeleportTrigger);
        }

    }



}

