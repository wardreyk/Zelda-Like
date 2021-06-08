using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EMD_ChangeScene : MonoBehaviour
{
    public string changingScene;
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
            isTeleportTrigger = true;
            Debug.Log(isTeleportTrigger);

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTeleportTrigger = false;
            Debug.Log(isTeleportTrigger);
        }

    }
}
