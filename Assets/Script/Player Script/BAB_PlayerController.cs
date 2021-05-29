using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    [SerializeField]
    Transform Player;

    Vector2 movement;

    [SerializeField]
    BDC_Corruption corruption;

    [SerializeField]
    BDC_MoovableRock moovableRock;
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

     
        if (Input.GetButtonDown("UseCapacity") && corruption.isCorrupted  == false) 
        {
                moovableRock.MoovableRock();
                
        }

    }

    private void FixedUpdate()
    {
        // Movement du personnage
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


 
}
