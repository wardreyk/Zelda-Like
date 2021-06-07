using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DetectHostileZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("HostileZoneTheme");
            Debug.Log("You are enter in Hostile Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Stop("HostileZoneTheme");
        Debug.Log("You leave the Hostile Zone");
    }
}
