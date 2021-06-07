using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMD_PressureDoor : MonoBehaviour
{
    public EMD_PressurePlate PressurePlate1;
    public EMD_PressurePlate PressurePlate2;
    public EMD_PressurePlate PressurePlate3;

    void Update()
    {
        if (PressurePlate1.isPressurePlateOn == true && PressurePlate2.isPressurePlateOn == true && PressurePlate3.isPressurePlateOn == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
