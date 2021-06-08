using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate3 : MonoBehaviour
{
    public bool isLeverOn3;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))

        {
            isLeverOn3 = true;
            FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
            animator.SetBool("PlatePress", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isLeverOn3 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
        {
            isLeverOn3 = false;
            FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
            animator.SetBool("PlatePress", false);
        }
    }
}

