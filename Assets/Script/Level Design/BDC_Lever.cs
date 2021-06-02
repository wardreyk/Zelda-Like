using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class BDC_Lever : MonoBehaviour
{

    public bool isLeverOn;

    public Tilemap nocolliderObject;


    public enum LeverFunctions {NoCollider, DestroyGameObject, }


    LeverFunctions leverFunctions;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            isLeverOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isLeverOn = false;

        }
    }


    public void LeverON()
    {
        switch(leverFunctions)
        {
            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;
       
                break;          
              case LeverFunctions.DestroyGameObject:
                   nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;
                    nocolliderObject.GetComponent<SpriteRenderer>().enabled = false;
                break;            
                    default:


                break;
           

        }


    }
        

}
