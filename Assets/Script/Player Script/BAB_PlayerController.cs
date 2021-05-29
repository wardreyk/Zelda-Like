using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5f;
    public bool isMoving;

    [SerializeField]
    Transform Player;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Initialisation du déplacement
        isMoving = false;

        // Inputs déplacements
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Animation Idle
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxis("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxis("Vertical"));
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        // Movement du personnage
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
