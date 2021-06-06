using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lever_Manager4 : MonoBehaviour
{


    public BDC_EmptyLever1 Lever1;
    public BDC_EmptyLever2 Lever2;
    public BDC_EmptyLever3 Lever3;
    public BDC_EmptyLever4 Lever4;
    public BDC_EmptyLever5 Lever5;



    public GameObject nocolliderObject;
    public GameObject destroyObject;

    public GameObject GOToActivate;
    public GameObject GoToDestroy;

    public GameObject GameObjectToActivate;


    public enum LeverFunctions { NoCollider, DestroyGameObject, ActivateGameObject, ActivateAndDestroy }

    [SerializeField]
    LeverFunctions leverFunctions;


    private void Update()
    {
        if (Lever2.isLeverOn2 == true && Lever1.isLeverOn1 == true && Lever3.isLeverOn3 && Lever4.isLeverOn4 && Lever5.isLeverOn5 == true)
        {
            LeverON();
        }
    }

    public void LeverON()
    {
        switch (leverFunctions)
        {

            case LeverFunctions.NoCollider:
                nocolliderObject.GetComponent<TilemapCollider2D>().enabled = false;



                break;
            case LeverFunctions.DestroyGameObject:
                destroyObject.GetComponent<BoxCollider2D>().enabled = false;
                destroyObject.GetComponent<SpriteRenderer>().enabled = false;

                break;
            case LeverFunctions.ActivateGameObject:
                GameObjectToActivate.SetActive(true);

                break;
            case LeverFunctions.ActivateAndDestroy:
                GoToDestroy.GetComponent<BoxCollider2D>().enabled = false;
                GoToDestroy.GetComponent<SpriteRenderer>().enabled = false;
                GOToActivate.SetActive(true);


                break;
            default:


                break;


        }
    }
}

