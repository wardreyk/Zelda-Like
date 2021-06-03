using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BDC_PressurePlate : MonoBehaviour
{
    public bool isLeverOn;

    public Tilemap nocolliderObject;
    public enum LeverFunctions { NoCollider, DestroyGameObject, NoColliderWithTimer, DestroyGameObjectWithTimer }

    [SerializeField]
    LeverFunctions leverFunctions;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            PressurePlateOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isLeverOn = false;

        }
    }


    public void PressurePlateOn()
    {
        switch (leverFunctions)
        {
            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;

                break;
            case LeverFunctions.DestroyGameObject:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;
                nocolliderObject.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case LeverFunctions.NoColliderWithTimer:
      
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:


                break;
            default:


                break;


        }


    }

    public void PressurePlateOff()
    {
        switch (leverFunctions)
        {
            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = true;

                break;
            case LeverFunctions.DestroyGameObject:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = true;
                nocolliderObject.GetComponent<SpriteRenderer>().enabled = true;
                break;
  
            default:


                break;


        }

    }
    public void DestroyGameObjectTimer()
    {
        float Timer;
        Timer = Time.deltaTime;

        
        nocolliderObject.GetComponent<TilemapCollider2D>().enabled = true;
        nocolliderObject.GetComponent<SpriteRenderer>().enabled = true;


    }


}
