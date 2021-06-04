﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerCombat : MonoBehaviour
{
    public BAB_PlayerController playerController;
    public LayerMask enemyLayers;
    public Transform attackPoint;

    [Range(0.5f, 5f)] public float attackRange = 2f; // Range de l'attaque melee
    [Range(10f, 30f)] public int currentattackDamage = 20; // Dégats de l'attaque melee

    public bool canAttack;

    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputAttack();
    }

    void InputAttack()
    {
        // Vérifie si l'input est appeler
        if (Input.GetButtonDown("AttackButton") && canAttack == true)
        {
            canAttack = false;
            playerController.animator.SetTrigger("SimpleAttack");
            MeleeAttack();
            StartCoroutine(CooldownBetweenAttack(0.5f));
            Debug.Log("Player try to attack");
        }
    }

    void MeleeAttack()
    {
        // Detecter les ennemis (Range de l'attaque) (détection du collider de l'enemy grace à un cercle posé sur l'attack point) 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Dégats infliger
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BAB_EnemyHealth>().TakeDamageEnemy(currentattackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator CooldownBetweenAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canAttack = true;
    }


}
