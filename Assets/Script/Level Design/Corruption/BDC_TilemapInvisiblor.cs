using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BDC_TilemapInvisiblor : MonoBehaviour
{

    public Tilemap corruptedTilemap;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        doInvisibleTilemap();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        restoreInvisibleTilemap();
    }

    public void doInvisibleTilemap()
    {

        corruptedTilemap.GetComponent<TilemapCollider2D>().enabled = false;
    //    corruptedTilemap.GetComponent<>().enabled = false;

    }

    public void restoreInvisibleTilemap()
    {
        corruptedTilemap.GetComponent<TilemapCollider2D>().enabled = true;
        //    corruptedTilemap.GetComponent<>().enabled = true;


    }
}
