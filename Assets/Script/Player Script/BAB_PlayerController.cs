using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Inputs déplacements
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Movement du personnage
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
