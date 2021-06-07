using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Reset : MonoBehaviour
{

    [SerializeField]
     Transform objectToReset;
    [SerializeField]
    Transform teleportPoint;

     bool isLeverOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLeverOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLeverOn = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isLeverOn == true)
        {
            DoReset();
        }
    }


    private void DoReset()
    {
        objectToReset.position = teleportPoint.position;


    }
}
