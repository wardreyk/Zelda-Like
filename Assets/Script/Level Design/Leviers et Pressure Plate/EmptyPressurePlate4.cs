using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate4 : MonoBehaviour
{
    public bool isLeverOn4;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))

        {
            isLeverOn4 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            isLeverOn4 = false;

        }
    }
}
