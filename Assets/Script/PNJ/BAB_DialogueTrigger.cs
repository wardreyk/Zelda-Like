using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_DialogueTrigger : MonoBehaviour
{
    public BAB_Dialogue dialogue;
    public BAB_DialogueManager dialogueManager;
    
    public GameObject InteractButton;

    public bool IsInRange = false;
    public bool DialogueOn = false;

    void Start()
    {
        InteractButton.SetActive(false);
        DialogueOn = false;
    }

    private void Update()
    {
        if (Input.GetButton("Interact") && IsInRange == true)
        {
            TriggerDialogue();
            DialogueOn = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<BAB_DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            InteractButton.SetActive(true);
            Debug.Log("Presse E");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueManager.EndDialogue();
        IsInRange = false;
        InteractButton.SetActive(false);
    }
}
