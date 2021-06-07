using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_EmptyLever2 : MonoBehaviour
{
    public bool isLeverOn2;
    bool collisionOn;


    private void Update()
    {
        if (collisionOn == true && Input.GetButtonDown("Interract"))
        {
            isLeverOn2 = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))

        {
            collisionOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            collisionOn = false;

        }
    }
}
