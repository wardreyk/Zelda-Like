using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PressurePlateManager2 : MonoBehaviour
{


    public EmptyPressurePlate Lever1;
    public EmptyPressurePlate2 Lever2;
    public EmptyPressurePlate3 Lever3;




    public GameObject nocolliderObject;
    public GameObject destroyObject;

    public GameObject GOToActivate;
    public GameObject GoToDestroy;

    public GameObject GameObjectToActivate;

    public GameObject DestroyDefinitely;


    public enum LeverFunctions { NoCollider, DestroyGameObject, ActivateGameObject, ActivateAndDestroy, DestroyDefinitely }

    [SerializeField]
    LeverFunctions leverFunctions;


    private void Update()
    {
        if (Lever2.isLeverOn2 == true && Lever1.isLeverOn1 == true && Lever3.isLeverOn3)
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
                destroyObject.SetActive(false);
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
}
