using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_EmptyLever1 : MonoBehaviour
{
    public bool isLeverOn1;
    bool collisionOn;



    private void Update()
    {
        if (collisionOn == true && Input.GetButtonDown("Interract"))
        {
            isLeverOn1 = true;
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
