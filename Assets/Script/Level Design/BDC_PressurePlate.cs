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
    public GameObject destroyObject;

    public GameObject GameObjectToActivate;

    public GameObject GOToActivate;
    public GameObject GoToDestroy;

    public GameObject DestroyDefinitely;
    public enum LeverFunctions { NoCollider, DestroyGameObject, NoColliderWithTimer, DestroyGameObjectWithTimer, ActivateGameObject, ActivateAndDestroy, DestroyDefinitely,}

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
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))

        {
        
                PressurePlateOn();
                isPressurePlateOn = true;


        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
        {
            PressurePlateOn();

            isPressurePlateOn = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock"))
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
                destroyObject.SetActive(false);
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
            case LeverFunctions.ActivateAndDestroy:
                GoToDestroy.SetActive(false);
                GOToActivate.SetActive(true);
                break;
            case LeverFunctions.DestroyDefinitely:
                DestroyDefinitely.SetActive(false);


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
                destroyObject.SetActive(true);
                break;
            case LeverFunctions.NoColliderWithTimer:
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:
                break;
            case LeverFunctions.ActivateGameObject:
                GameObjectToActivate.SetActive(false);
                break;
            case LeverFunctions.ActivateAndDestroy:
                GoToDestroy.SetActive(true);
                GOToActivate.SetActive(false);
                break;
            case LeverFunctions.DestroyDefinitely:

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
