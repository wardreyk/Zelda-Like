using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_BushMove : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("BushMove",true);
            Debug.Log("Bush move");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("BushMove", false);
    }
}
