using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class BDC_Corruption : MonoBehaviour
{
    public bool corruptionOn; 

    public TilemapDestructor tilemapDestructor;
    public EMD_InvisibleTilemap tilemapDestructorProps;
    public BAB_PlayerCombat playerCombat;

    public GameObject TownZone;
    public GameObject TempleZone;
    public GameObject HostileZone;
    public GameObject DonjonZone;
    public GameObject BossZone;

    public GameObject corruption;
    public GameObject postProcessing8bit;

    [SerializeField]
    NavMeshSurface2d surface;

    public GameObject parasite;
    public Transform parasitee;

    public Transform player;
    public GameObject playere;
    public Rigidbody2D rigidbodyPlayer;

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
                corruptionOn = true;
                DesactivateAttackPlayer();
                TownZone.SetActive(false);
                TempleZone.SetActive(false);
                HostileZone.SetActive(false);
                DonjonZone.SetActive(false);
                BossZone.SetActive(false);
                FindObjectOfType<BAB_AudioManager>().Play("SwitchCorruptionSound");
                StartCoroutine(StartCorruptionTheme(1f));
                mainCamera.Follow = parasiteTransform;
                mainCamera.LookAt = parasiteTransform;
                doCorruption();
                doParasite();
                tilemapDestructor.destroyTilemap();
                tilemapDestructorProps.HideTilemap();
                print("corruptionactiv�");
            }

            else if (isCorrupted == true)
            {
                corruptionOn = false;
                ActivateAttackPlayer();
                TownZone.SetActive(true);
                TempleZone.SetActive(true);
                HostileZone.SetActive(true);
                DonjonZone.SetActive(true);
                BossZone.SetActive(true);
                FindObjectOfType<BAB_AudioManager>().Stop("CorruptionTheme");
                mainCamera.Follow = playerTransform;
                mainCamera.LookAt = playerTransform;
                stopCorruption();
                stopParasite();
                DoubleParasiteOff();
                tilemapDestructor.restoreTilemap();
                tilemapDestructorProps.ShowTilemap();
                print("corruptiond�sactiv�");
            }

        }

        if (Input.GetButtonDown("UseCapacity"))
        {
            if (isCorrupted == true)
            {
                FindObjectOfType<BAB_AudioManager>().Play("CloneSound");
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


        rigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePosition;

        playere.GetComponent<BAB_PlayerController>().enabled = false;
            parasite.SetActive(true);
            

        }



        public void stopParasite()
        {
         rigidbodyPlayer.constraints = RigidbodyConstraints2D.None;
        rigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;

        parasite.SetActive(false);
        parasitee.position = player.position;
            playere.GetComponent<BAB_PlayerController>().enabled = true;
        }

        public void DoubleParasiteOn()
        {
        GameObject dParasiteOnBoard;
            if (doubleParasiteOn == false)
            {
                Instantiate(dParasite, parasitee.transform.position, parasitee.transform.rotation);
                doubleParasiteOn = true;

              
            }
            else if (doubleParasiteOn == true)
            {
            dParasiteOnBoard = GameObject.Find("dParasite(Clone)");
                Destroy(dParasiteOnBoard);
                doubleParasiteOn = false;
            }
        }
        public void DoubleParasiteOff()
        {
        GameObject dParasiteOnBoard;
        if (doubleParasiteOn == true)
            {
            dParasiteOnBoard = GameObject.Find("dParasite(Clone)");
            Destroy(dParasiteOnBoard);
                doubleParasiteOn = false;
            }
        }

    void DesactivateAttackPlayer()
    {
        if (corruptionOn == true)
        {
            playerCombat.canAttack = false;
        }
        else
        {
            playerCombat.canAttack = true;
        }
    }

    void ActivateAttackPlayer()
    {
        if (corruptionOn == false)
        {
            playerCombat.canAttack = true;
        }
    }

    IEnumerator StartCorruptionTheme(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<BAB_AudioManager>().Play("CorruptionTheme");
    }

 }


