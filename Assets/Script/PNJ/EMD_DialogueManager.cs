using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EMD_DialogueManager : MonoBehaviour
{
    //public TextMeshProUGUI textDisplay;

    public bool IsWriting;
    public bool DialogueIsActive;
    private int index;
    public float DelayTime;
    public string[] sentences = new string[5];
    public string PNJName;

    public GameObject ActualNPC;
    //public GameObject DialogueCanvas;


    void Start()
    {
        
    }

    void Update()
    {
        if (DialogueIsActive && (Input.GetKeyDown(KeyCode.Escape)))
        {
            QuitDialogue();
        }
    }
    public void QuitDialogue()
    {
        if (IsWriting == false)
        {
            //DialogueCanvas.SetActive(false);
            index = 0;
            //textDisplay.text = "";
            DialogueIsActive = false;
            //PlayerMovesScript.ToggleMenu();
        }
    }
    IEnumerator Type()
    {
        IsWriting = true;

        foreach (char letter in sentences[index].ToCharArray())
        {
            //textDisplay.text += letter;
            yield return new WaitForSeconds(DelayTime);
        }

        IsWriting = false;
    }
    public IEnumerator StartDialogue()
    {
        //PNJType = ActualNPC.GetComponent<EMD_Sentences>().PNJType;
        sentences = ActualNPC.GetComponent<EMD_Sentences>().sentences;
        if (PNJName == "PassiveMerchant")
        {
            //PassiveButton.SetActive(true);
        }
        else if (PNJName == "AchievementsMerchant")
        {
            //AchievementsButton.SetActive(true);
        }
        else if (PNJName == "InformationPNJ")
        {
            //PNJInfoButton.SetActive(true);
        }
        DialogueIsActive = true;
        StartCoroutine("Type");
        //yield return new WaitWhile(() => IsWriting == true);
        yield return null;
    }
}
