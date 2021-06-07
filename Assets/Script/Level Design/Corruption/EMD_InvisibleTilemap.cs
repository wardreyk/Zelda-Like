using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class EMD_InvisibleTilemap : MonoBehaviour
{
    public BDC_Corruption corruption;

    public void HideTilemap()
    {
        gameObject.GetComponent<TilemapRenderer>().enabled = false;
    }

    public void ShowTilemap()
    {
        gameObject.GetComponent<TilemapRenderer>().enabled = true;
    }
}
