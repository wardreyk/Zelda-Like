using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BDC_PressurePlate : MonoBehaviour
{
    public bool isPressurePlateOn;

    private float Timer;

    public float waitTimeDestroy;
    public float waitTimeNoCollider;

    public float waitTimeTimer;

    public Tilemap nocolliderObject;
    public Tilemap destroyObject;

    public GameObject GameObjectToActivate;
    public enum LeverFunctions { NoCollider, DestroyGameObject, NoColliderWithTimer, DestroyGameObjectWithTimer, ActivateGameObject }

    [SerializeField]
    LeverFunctions leverFunctions;

    private void Update()
    {
        if (Timer > waitTimeDestroy)
        {
            DestroyGameObjectTimer();
        }
        if (Timer > waitTimeNoCollider)
        {
            NoColliderObjecTimer();
        }
        if (Timer > waitTimeTimer)
        {
            Timer = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !collision.gameObject.CompareTag("Parasite"))

        {
        
                PressurePlateOn();
                isPressurePlateOn = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &! collision.gameObject.CompareTag("Parasite"))
        {
            PressurePlateOff();
            isPressurePlateOn = false;

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
                destroyObject.GetComponent<TilemapCollider2D>().enabled = false;
                destroyObject.GetComponent<TilemapRenderer>().enabled = false;

                break;
            case LeverFunctions.NoColliderWithTimer:
                StartTimer();
  
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:
                StartTimer();
   
                break;

            case LeverFunctions.ActivateGameObject:
                GameObjectToActivate.SetActive(true);
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
                destroyObject.GetComponent<TilemapCollider2D>().enabled = true;
                destroyObject.GetComponent<TilemapRenderer>().enabled = true;
                break;

            case LeverFunctions.NoColliderWithTimer:
                Timer = 0;
            break;
             case LeverFunctions.DestroyGameObjectWithTimer:
                Timer = 0;
                break;
            default:


                break;


        }

    }
    public void DestroyGameObjectTimer()
    {
        destroyObject.GetComponent<TilemapCollider2D>().enabled = true;
        destroyObject.GetComponent<TilemapRenderer>().enabled = true;

    }
    public void NoColliderObjecTimer()
    {
        nocolliderObject.GetComponent<TilemapCollider2D>().enabled = true;
        
    }

    public void StartTimer()
    {
        Timer += Time.deltaTime;


    }
}
