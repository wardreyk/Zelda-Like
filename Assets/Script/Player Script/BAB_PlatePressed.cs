using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlatePressed : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PlatePress", true);
            Debug.Log("Plate is pressed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("PlatePress", false);
    }
}
