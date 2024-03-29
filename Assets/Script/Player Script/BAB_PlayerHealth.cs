﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAB_PlayerHealth : MonoBehaviour
{
    public GameObject player;

    public int currentHealth;
    public int numofHearts;
    public int maxHealth = 8;
    public int minHealth = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        // Initialise la vie au max
        currentHealth = maxHealth;
    }
    private void Update()
    {
        // Test damage
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
            Debug.Log("Player take 1 Damage");
        }

        // Ajustement de la vie
        if (currentHealth >= numofHearts)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= minHealth)
        {
            currentHealth = minHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            // Vérifie la vie du personnage
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Ajoute ou supprime des coeurs 
            if(i < numofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= minHealth)
        {
            Death();
        }
    }

    public void Death()
    {
        player.SetActive(false);
        Debug.Log("YOU ARE DEAD");
    }

}
