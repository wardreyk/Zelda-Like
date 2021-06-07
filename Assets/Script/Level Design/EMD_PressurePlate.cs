using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EMD_PressurePlate : MonoBehaviour
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
    public enum LeverFunctions { NoCollider, DestroyGameObject, NoColliderWithTimer, DestroyGameObjectWithTimer, ActivateGameObject, ActivateAndDestroy, Nothing }

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
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Ennemy"))

        {

            isPressurePlateOn = true;
            PressurePlateOn();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite") || collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Ennemy"))
        {
            PressurePlateOff();
            isPressurePlateOn = false;

        }
    }


    public void PressurePlateOn()
    {
        switch (leverFunctions)
        {
            case LeverFunctions.Nothing:
                isPressurePlateOn = true;
                break;

            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;

                break;
            case LeverFunctions.DestroyGameObject:
                destroyObject.GetComponent<BoxCollider2D>().enabled = false;
                destroyObject.GetComponent<SpriteRenderer>().enabled = false;

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
                GoToDestroy.GetComponent<TilemapCollider2D>().enabled = false;
                GoToDestroy.GetComponent<TilemapRenderer>().enabled = false;
                GOToActivate.SetActive(true);
                break;
            default:


                break;


        }


    }

    public void PressurePlateOff()
    {
        switch (leverFunctions)
        {
            case LeverFunctions.Nothing:
                isPressurePlateOn = false;
                break;

            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = true;

                break;
            case LeverFunctions.DestroyGameObject:
                destroyObject.GetComponent<BoxCollider2D>().enabled = true;
                destroyObject.GetComponent<SpriteRenderer>().enabled = true;
                break;

            case LeverFunctions.NoColliderWithTimer:
                Timer = 0;
                break;
            case LeverFunctions.DestroyGameObjectWithTimer:
                Timer = 0;
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
