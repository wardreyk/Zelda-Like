using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_DownCollider : MonoBehaviour
{
    [SerializeField]
    BDC_MoovableRock moovableRock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            moovableRock.downColliderOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moovableRock.downColliderOn = false;
            moovableRock.UnMoovableRock();
        }
    }

}