using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_LeftCollider : MonoBehaviour
{
    [SerializeField]
    BDC_MoovableRock moovableRock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))

        {
            moovableRock.leftColliderOn = true;



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {

            moovableRock.leftColliderOn = false;
            moovableRock.UnMoovableRock();

        }
    }

}
