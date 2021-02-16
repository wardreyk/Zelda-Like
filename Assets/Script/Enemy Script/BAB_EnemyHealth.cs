using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_EnemyHealth : MonoBehaviour
{
    public GameObject himself;
    public Animator animatorEnemy;

    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //initialisation de la vie enemis au 
        currentHealth = maxHealth;
    }

    public void TakeDamageEnemy(int Damage)
    {
        // vie actuelle - les dégats infliger + knockback de l'ennemis
        currentHealth -= Damage;
        animatorEnemy.SetTrigger("Hit");

        Debug.Log("Enemy take damage");

        // Mort de l'ennemis
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Désactiver l'enemis
        GetComponent<Collider2D>().enabled = false;
        himself.SetActive(false);
        Debug.Log("Enemy died!");
    }
}
