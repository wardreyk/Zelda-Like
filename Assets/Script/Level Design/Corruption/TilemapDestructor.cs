using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TilemapDestructor : MonoBehaviour
{   
    public BDC_Corruption corruption;

    public void destroyTilemap()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        gameObject.GetComponent<TilemapRenderer>().enabled = false;
    }

    public void restoreTilemap()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        gameObject.GetComponent<TilemapRenderer>().enabled = true;
    }
}
