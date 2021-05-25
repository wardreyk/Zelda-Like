using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BDC_InvisibleTilemap : MonoBehaviour
{

    public bool isInvisible;

    [SerializeField]
    BDC_Corruption corruption;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        corruption.corruptedTilemap.GetComponent<TilemapRenderer>().enabled = false;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        corruption.corruptedTilemap.GetComponent<TilemapRenderer>().enabled = true;

    }








}
