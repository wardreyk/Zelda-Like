using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_GoldPickup : MonoBehaviour
{
    public int gold;
    public BAB_MoneyManager moneyManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            moneyManager.AddMoney(gold);
            Destroy(gameObject);
        }
    }
}
