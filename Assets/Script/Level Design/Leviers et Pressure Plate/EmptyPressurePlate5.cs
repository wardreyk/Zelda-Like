using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate5 : MonoBehaviour
{
    public bool isLeverOn5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))

        {
            isLeverOn5 = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isLeverOn5 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
        {
            isLeverOn5 = false;

        }
    }
}
