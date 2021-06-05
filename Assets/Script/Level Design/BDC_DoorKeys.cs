using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_DoorKeys : MonoBehaviour
{
    public BDC_Keys keys;
    public GameObject DoorKeys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && keys.keyOn == true)
        {
            Houdini();
        }
    }
    private void Houdini()
    {

        keys.GetComponent<SpriteRenderer>().enabled = false;
        keys.GetComponent<BoxCollider2D>().enabled = false;
    }
}
