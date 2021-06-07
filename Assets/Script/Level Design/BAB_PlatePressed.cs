using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlatePressed : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Parasite"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
            animator.SetBool("PlatePress", true);
            Debug.Log("Plate is pressed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
        animator.SetBool("PlatePress", false);
    }
}
