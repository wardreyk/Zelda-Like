using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DetectBossZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("BossZoneTheme");
            Debug.Log("You are enter in Boss Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Stop("BossZoneTheme");
        Debug.Log("You leave the Boss Zone");
    }
}
