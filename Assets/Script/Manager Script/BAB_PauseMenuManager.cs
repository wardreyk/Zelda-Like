using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BAB_PauseMenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseFirstButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        //Clear la selection des boutton UI
        EventSystem.current.SetSelectedGameObject(null);
        // Selection d'un nouveau boutton
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
    
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BAB_Scene_Main_Menu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
