using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate2 : MonoBehaviour
{
    public bool isLeverOn2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))

        {
            isLeverOn2 = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isLeverOn2 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
        {
            isLeverOn2 = false;

        }
    }
}
