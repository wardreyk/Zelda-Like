using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerCombat : MonoBehaviour
{
    public bool canAttack;
    
    public LayerMask enemyLayers;
    public LayerMask jarLayers;
    public LayerMask bushLayers;

    public BAB_PlayerController playerController;
    public Transform attackPoint;

    [Range(0f, 5f)] public float attackRange = 2f; // Range de l'attaque melee
    [Range(10f, 50f)] public int currentattackDamage = 35; // Dégats de l'attaque melee

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
            FindObjectOfType<BAB_AudioManager>().Play("AttackSound");
            playerController.animator.SetTrigger("SimpleAttack");
            MeleeAttack();
            AttackJar();
            AttackBush();
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

    void AttackJar()
    {
        // Detecter les ennemis (Range de l'attaque) (détection du collider de l'enemy grace à un cercle posé sur l'attack point) 
        Collider2D[] hitjar = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, jarLayers);

        // Dégats infliger
        foreach (Collider2D jar in hitjar)
        {
            jar.GetComponent<BAB_DestroyJar>().DestroyJar();
        }
    }

    void AttackBush()
    {
        // Detecter les ennemis (Range de l'attaque) (détection du collider de l'enemy grace à un cercle posé sur l'attack point) 
        Collider2D[] hitbush = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bushLayers);

        // Dégats infliger
        foreach (Collider2D bush in hitbush)
        {
            bush.GetComponent<BAB_BushMove>().DestroyBush();
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
