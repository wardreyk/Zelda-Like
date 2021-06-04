using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Chest : MonoBehaviour
{
    public bool chestOn;


    [SerializeField]
    BAB_MoneyManager moneyManager;
    void Update()
    {
        if (chestOn == true  && Input.GetKeyDown("Interract"))
        {
            moneyManager.AddMoney(AddGold:1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chestOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chestOn = false;
    }
}