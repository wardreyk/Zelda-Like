using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class BDC_Corruption : MonoBehaviour
{
    bool isCorrupted;

    public TilemapDestructor tilemapDestructor;

    GameObject corruption;

    [SerializeField]
    NavMeshSurface2d surface;

    public GameObject parasite;

    public Transform player;
    public GameObject playere;



    private void Start()
    {
        corruption = GameObject.Find("Corruption");
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (isCorrupted == true)
            {
                doCorruption();
                tilemapDestructor.destroyTilemap();
            }

            if (isCorrupted == false)
            {
                stopCorruption();
                tilemapDestructor.restoreTilemap();
            }

        }
    }


    public void doCorruption()
    {
        corruption.SetActive(true);
        isCorrupted = true;
    }

    public void stopCorruption()
    {
        corruption.SetActive(false);
        isCorrupted = false;
    }

    public void doParasite()
    {
        Instantiate(parasite,player);
        playere.GetComponent<BoxCollider2D>().enabled = false;
        playere.GetComponent<BAB_PlayerController>().enabled = false;
       
    }



    public void stopParasite()
    {
        playere.GetComponent<BoxCollider2D>().enabled = true;
        playere.GetComponent<BAB_PlayerController>().enabled = true;
        Destroy(parasite);

    }
}
