using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DetectDonjonZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("DonjonZoneTheme");
            Debug.Log("You are enter in Donjon Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Stop("DonjonZoneTheme");
        Debug.Log("You leave the Donjon Zone");
    }
}
