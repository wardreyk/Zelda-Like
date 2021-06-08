using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPressurePlate : MonoBehaviour
{
    public bool isLeverOn1;
    public Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))

        {
            isLeverOn1 = true;
            FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
            animator.SetBool("PlatePress", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isLeverOn1 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
        {
            isLeverOn1 = false;
            FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
            animator.SetBool("PlatePress", false);
        }
    }
}

