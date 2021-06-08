using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAB_MoneyManager : MonoBehaviour
{
    public Text moneyText;
    public int currentGold;
    public BAB_PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (currentGold <= 0)
        {
            currentGold = 0;
        }
    }

    public void AddMoney(int AddGold)
    {
        currentGold += AddGold;
        playerHealth.currentHealth += 8;
        moneyText.text = "Parchemin : " + currentGold;
    }
}
