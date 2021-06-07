using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DetecTempletZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("TempleZoneTheme");
            Debug.Log("You are enter in Temple Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Stop("TempleZoneTheme");
        Debug.Log("You leave the Temple Zone");
    }
}
