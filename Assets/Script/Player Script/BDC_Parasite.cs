using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_Parasite : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    [SerializeField]
    GameObject Trap;


    Vector2 movement;


    public BDC_Corruption corruption;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


        if (Input.GetButtonDown("AttackButton") && corruption.isCorrupted == true)
        {
            Instantiate(Trap, gameObject.transform);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
