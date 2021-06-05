using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class BDC_Lever : MonoBehaviour
{

     bool isLeverOn;
    private float Timer;

    public bool doEffect;


    public float waitTimeDestroy;
    public float waitTimeNoCollider;

    public float waitTimeTimer;

    public Tilemap nocolliderObject;
    public Tilemap destroyObject;

    public GameObject GOToActivate;
    public GameObject GoToDestroy;

    public GameObject GameObjectToActivate;


    public enum LeverFunctions {NoCollider, DestroyGameObject, NoColliderWithTimer, DestroyGameObjectWithTimer, ActivateGameObject, ActivateAndDestroy }

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
        if (Input.GetButtonDown("Interact") && isLeverOn == true)
        {
            if (doEffect == false)
            {
                LeverON();
                BDC_ScreenShake.Instance.ShakeCamera(5f, 1f);
            }
            else if (doEffect == true)
            {
                LeverOFF();
                doEffect = false;
                BDC_ScreenShake.Instance.ShakeCamera(5f, 1f);
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &! collision.gameObject.CompareTag("Parasite"))

        {
            isLeverOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !collision.gameObject.CompareTag("Parasite"))
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
                doEffect = true;


                break;          
              case LeverFunctions.DestroyGameObject:
                   destroyObject.GetComponent<TilemapCollider2D>().enabled = false;
                destroyObject.GetComponent<TilemapRenderer>().enabled = false;
                doEffect = true;
                break;
            case LeverFunctions.NoColliderWithTimer:
                StartTimer();
                doEffect = true;
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:
              StartTimer();
                doEffect = true;
                break;
            case LeverFunctions.ActivateGameObject:
                GameObjectToActivate.SetActive(true);
                doEffect = true;
                break;
            case LeverFunctions.ActivateAndDestroy:
                GoToDestroy.GetComponent<TilemapCollider2D>().enabled = false;
                GoToDestroy.GetComponent<TilemapRenderer>().enabled = false;
                GOToActivate.SetActive(true);
                break;
            default:


                break;
           

        }


    }
    public void LeverOFF()
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
                StartTimer();
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:
                StartTimer();
                break;
            case LeverFunctions.ActivateGameObject:
                GameObjectToActivate.SetActive(false);
                break;
            case LeverFunctions.ActivateAndDestroy:
                GoToDestroy.GetComponent<TilemapCollider2D>().enabled = true;
                GoToDestroy.GetComponent<TilemapRenderer>().enabled = true;
                GOToActivate.SetActive(false);
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
