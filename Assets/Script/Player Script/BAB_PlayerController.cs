using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerController : MonoBehaviour
{
    public bool isMoving;
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;
    public Animator animator;


    [SerializeField]
    Transform Player;

    [SerializeField]
    BDC_Lever Lever;

    [SerializeField]
    BDC_PressurePlate pressurePlate;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Initialisation du déplacement
        isMoving = false;

        // Inputs déplacements
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
    }

    private void FixedUpdate()
    {
        // Movement du personnage
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
