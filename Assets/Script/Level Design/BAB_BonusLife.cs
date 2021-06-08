using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_BonusLife : MonoBehaviour
{
    public BAB_PlayerHealth playerHealth;
    public GameObject coeur;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BAB_AudioManager>().Play("BonusLifeSound");
            playerHealth.currentHealth += 3;
            coeur.SetActive(false);
        }
    }
}
