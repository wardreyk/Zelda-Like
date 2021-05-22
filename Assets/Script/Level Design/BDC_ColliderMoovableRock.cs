using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDC_ColliderMoovableRock : MonoBehaviour
{
    public enum Collider
    {
        VerticalCollider,
        HorizontalCollider
    }


    Collider currentCollider;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentCollider == Collider.HorizontalCollider )
        {

        }
        if (currentCollider == Collider.VerticalCollider)
        {

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (currentCollider == Collider.HorizontalCollider)
        {

        }
        if (currentCollider == Collider.VerticalCollider)
        {

        }
    }
}
