using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TilemapDestructor : MonoBehaviour
{   
    [SerializeField]
    NavMeshSurface2d surface;

    void Start()
    {

    }

    public void destroyTilemap()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        gameObject.GetComponent<TilemapRenderer>().enabled = false;
        surface.BuildNavMesh();
    }

    public void restoreTilemap()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        gameObject.GetComponent<TilemapRenderer>().enabled = true;
        surface.BuildNavMesh();
    }
}
