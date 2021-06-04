using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Keys : MonoBehaviour
{
    public bool keyOn;

    public GameObject keys;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {

            Houdini();
            keyOn = true;


        }
    }

    private void Houdini()
    {

        keys.GetComponent<SpriteRenderer>().enabled = false;

    }
}
