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
        //initialisation de la vie enemis au max
        currentHealth = maxHealth;
    }

    public void TakeDamageEnemy(int Damage)
    {
        // vie actuelle - les dégats infliger + knockback de l'ennemis
        currentHealth -= Damage;
        FindObjectOfType<BAB_AudioManager>().Play("EnemyHit");
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
        FindObjectOfType<BAB_AudioManager>().Play("EnemyDie");
        animatorEnemy.SetTrigger("Death");
        StartCoroutine(WaitDeath(1f));
        Debug.Log("Enemy died!");
    }

    IEnumerator WaitDeath(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Collider2D>().enabled = false;
        himself.SetActive(false);
    }
}
