using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_EnemyAttack : MonoBehaviour
{

public BAB_PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
            Debug.Log("Take a damage");
        }
    }
}
