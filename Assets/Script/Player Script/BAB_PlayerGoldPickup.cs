using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerGoldPickup : MonoBehaviour
{
    public int gold;
    public BAB_MoneyManager moneyManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("PickupCoin");
            moneyManager.AddMoney(gold);
            Destroy(gameObject);
            Debug.Log("1 gold pickup");
        }
    }
}
