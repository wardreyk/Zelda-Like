using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class BDC_Corruption : MonoBehaviour
{

    public TilemapDestructor tilemapDestructor;

   public GameObject corruption;
    public GameObject postProcessing8bit;

    [SerializeField]
    NavMeshSurface2d surface;

    public GameObject parasite;
    public Transform parasitee;

    public Transform player;
    public GameObject playere;

    public GameObject corruptedTilemap;

    public GameObject dParasite;

    bool doubleParasiteOn;

    public bool isCorrupted;

    public CinemachineVirtualCamera mainCamera;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform parasiteTransform;




    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            if (isCorrupted == false)
            {
                mainCamera.Follow = parasiteTransform;
                mainCamera.LookAt = parasiteTransform;
                doCorruption();
                doParasite();
                tilemapDestructor.destroyTilemap();
                print("corruptionactivé");
            }

            else if (isCorrupted == true)
            {
                mainCamera.Follow = playerTransform;
                mainCamera.LookAt = playerTransform;
                stopCorruption();
                stopParasite();
                DoubleParasiteOff();
                tilemapDestructor.restoreTilemap();
                print("corruptiondésactivé");
            }

        }

        if (Input.GetButtonDown("UseCapacity"))
        {
            if (isCorrupted == true)
            {
                DoubleParasiteOn();
            }



        }

    }
        public void doCorruption()
        {
            corruption.SetActive(true);
            postProcessing8bit.SetActive(false);
            isCorrupted = true;

        }

        public void stopCorruption()
        {
            corruption.SetActive(false);
            postProcessing8bit.SetActive(true);
            isCorrupted = false;
        }

        public void doParasite()
        {
            playere.GetComponent<BoxCollider2D>().enabled = false;
            playere.GetComponent<BAB_PlayerController>().enabled = false;
            parasite.SetActive(true);


        }



        public void stopParasite()
        {
            parasite.SetActive(false);
            parasitee.position = player.position;
            playere.GetComponent<BoxCollider2D>().enabled = true;
            playere.GetComponent<BAB_PlayerController>().enabled = true;
        }

        public void DoubleParasiteOn()
        {
            if (doubleParasiteOn == false)
            {
                Instantiate(dParasite, parasitee.transform.position, parasitee.transform.rotation);
                doubleParasiteOn = true;
            }
            if (doubleParasiteOn == true)
            {
                Destroy(dParasite);
                doubleParasiteOn = false;
            }
        }
        public void DoubleParasiteOff()
        {
            if (doubleParasiteOn == true)
            {
                Destroy(dParasite);
                doubleParasiteOn = false;
            }
        }




    
}
