using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BAB_GameManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Continue()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
