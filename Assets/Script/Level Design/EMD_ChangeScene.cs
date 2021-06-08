using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EMD_ChangeScene : MonoBehaviour
{
    public string changingScene;
    public GameObject interactButton;
    bool isTeleportTrigger;

    private void Update()
    {
        if (isTeleportTrigger == true && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadSceneAsync(changingScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactButton.SetActive(true);
            isTeleportTrigger = true;
            Debug.Log(isTeleportTrigger);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactButton.SetActive(false);
            isTeleportTrigger = false;
            Debug.Log(isTeleportTrigger);
        }

    }
}
