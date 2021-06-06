using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BAB_DialogueTriggerParasite : MonoBehaviour
{
    public bool IsInRange = false;
    public bool DialogueOn = false;
    
    public BAB_Dialogue dialogue;
    public BAB_DialogueManager dialogueManager;
    
    public GameObject dialogueFirstButton;

    public void TriggerDialogue()
    {
        FindObjectOfType<BAB_DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            DialogueOn = true;
            TriggerDialogue();

            //Clear la selection des boutton UI
            EventSystem.current.SetSelectedGameObject(null);
            // Selection d'un nouveau boutton
            EventSystem.current.SetSelectedGameObject(dialogueFirstButton);
            Debug.Log("Le parasite me parle...");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueManager.EndDialogue();
        IsInRange = false;
    }
}
