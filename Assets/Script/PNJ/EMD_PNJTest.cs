using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMD_PNJTest : MonoBehaviour
{
    public bool IsInRange = false;
    public bool DialogueOn = false;
    public GameObject IdlePNJ;
    public GameObject DialogueManager;
    private EMD_DialogueManager DialogueManagerScript;
    void Start()
    {
        IdlePNJ.SetActive(false);
        DialogueManagerScript = DialogueManager.GetComponent<EMD_DialogueManager>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Interact")) && IsInRange == true && !DialogueManagerScript.DialogueIsActive)
        {
            Debug.Log("Interaction");
            DialogueManagerScript.ActualNPC = this.gameObject;
            DialogueManagerScript.StartCoroutine("StartDialogue");
        }
        else if (DialogueManagerScript.DialogueIsActive == true)
        {
            DialogueManagerScript.DialogueIsActive = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            IdlePNJ.SetActive(true);
            Debug.Log("C'est un bon joueur !");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInRange = false;
        IdlePNJ.SetActive(false);
    }
}
