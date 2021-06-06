using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate : MonoBehaviour
{
    public bool isLeverOn1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))

        {
            isLeverOn1 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            isLeverOn1 = false;

        }
    }
}

