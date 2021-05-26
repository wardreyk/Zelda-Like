using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Trap : MonoBehaviour
{

    private float trapTimer;
    private bool onTrap;
  

void Update()
    {
        
        if (onTrap == true)
        {
           trapTimer += Time.deltaTime;
                
        }

        if (trapTimer == 1.5f)
        {
            print("Wesh");
            trapTimer = 0;
            onTrap = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        onTrap = true;
    }


    private void OnCollisionExit2D(Collision2D col)
    {
        onTrap = false;
    }

    private void DestroyTrap()
    {



    }
}