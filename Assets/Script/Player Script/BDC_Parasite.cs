using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Parasite : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5f;

    private int trapCounter;

    [SerializeField]
    GameObject Trap;

    Vector2 movement;

    public BDC_Corruption corruption;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Animation Déplacement
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Animation Idle
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("AttackButton") && corruption.isCorrupted == true && trapCounter < 5)
        {
            FindObjectOfType<BAB_AudioManager>().Play("TrapSound");
            Instantiate(Trap, transform.position, transform.rotation);
               
                trapCounter++;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
