using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_BushMove : MonoBehaviour
{
    public Animator animator;
    public GameObject bush;

    public void DestroyBush()
    {
        animator.SetBool("BushDestruction", true);
        bush.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(DesactivateBush(0.4f));
        Debug.Log("Bush Destroy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("WalkInBush");
            animator.SetBool("BushMove",true);
            Debug.Log("Bush move");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("BushMove", false);
    }

    IEnumerator DesactivateBush(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bush.SetActive(false);
    }
}
