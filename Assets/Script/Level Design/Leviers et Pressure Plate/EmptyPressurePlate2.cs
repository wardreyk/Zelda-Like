using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate2 : MonoBehaviour
{
    public bool isLeverOn2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))

        {
            isLeverOn2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            isLeverOn2 = false;

        }
    }
}
