using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_UpCollider : MonoBehaviour
{
    [SerializeField]
    BDC_MoovableRock moovableRock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            moovableRock.upColliderOn = true;
       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            moovableRock.upColliderOn = false;
            moovableRock.UnMoovableRock();
        }
    }
}
