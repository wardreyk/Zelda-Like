using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DetectTownZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("TownZoneTheme");
            Debug.Log("You are enter in Town Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Stop("TownZoneTheme");
        Debug.Log("You leave the Town Zone");
    }
}
