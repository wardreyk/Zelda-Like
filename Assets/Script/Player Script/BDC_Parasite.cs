using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Parasite : MonoBehaviour
{
    public Rigidbody2D rb;

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


        if (Input.GetButtonDown("AttackButton") && corruption.isCorrupted == true && trapCounter < 5)
        {
     
           Instantiate(Trap, transform.position, transform.rotation);
               
                trapCounter++;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
