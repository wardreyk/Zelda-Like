using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAB_PlayerHealth : MonoBehaviour
{

    public int health;
    public int numofHearts;
    public int maxHealth = 8;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Vérifie la vie du personnage
            if(i < health)
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

            if(health >= numofHearts)
            {
                health = maxHealth;
            }
        }
    }

}
