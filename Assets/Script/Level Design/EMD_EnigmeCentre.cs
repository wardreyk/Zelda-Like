using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EMD_EnigmeCentre : MonoBehaviour
{
    bool isLeverOn;

    public bool doEffect;

    public GameObject Door1;
    public GameObject Door2;

    public Animator animator;


    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isLeverOn == true)
        {
            if (doEffect == false)
            {
                FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
                animator.SetBool("LeverOn", true);
                LeverON();
            }
            else if (doEffect == true)
            {
                FindObjectOfType<BAB_AudioManager>().Play("SwitchSound");
                animator.SetBool("LeverOn", false);
                LeverOFF();
                doEffect = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            isLeverOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Parasite"))
        {
            isLeverOn = false;
        }
    }


    public void LeverON()
    {
        if (Door1.activeSelf)
        {
            Door1.SetActive(false);
            doEffect = true;
        }
        else
        {
            Door1.SetActive(true);
            doEffect = true;
        }
        if (Door2.activeSelf)
        {
            Door2.SetActive(false);
            doEffect = true;
        }
        else
        {
            Door2.SetActive(true);
            doEffect = true;
        }
    }
    public void LeverOFF()
    {
        if (Door1.activeSelf)
        {
            Door1.SetActive(false);
        }
        else
        {
            Door1.SetActive(true);
        }
        if (Door2.activeSelf)
        {
            Door2.SetActive(false);
        }
        else
        {
            Door2.SetActive(true);
        }
    }
}