using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform teleportPoint;

    public Transform player;

    bool isTeleportTrigger;

    public GameObject interactButton;
    public GameObject loadScreed;


    private void Update()
    {
        if (isTeleportTrigger == true && Input.GetButtonDown("Interact"))
        {
            loadScreed.SetActive(true);
            player.position = teleportPoint.position;
            StartCoroutine(DesactiveLoadScreen(1.5f));
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
            interactButton.SetActive(true);
            isTeleportTrigger = true;
            Debug.Log(isTeleportTrigger);
            }

        }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            isTeleportTrigger = false;
            Debug.Log(isTeleportTrigger);
        }

    }
    IEnumerator DesactiveLoadScreen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        loadScreed.SetActive(false);
    }

}

