using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DestroyJar : MonoBehaviour
{
    public Animator animator;
    public GameObject jar;

    public void DestroyJar()
    {
        animator.SetBool("IsDestroy", true);
        jar.GetComponent<BoxCollider2D>().enabled = false;
    }
}
