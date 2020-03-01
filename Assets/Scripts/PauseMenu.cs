using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{

    public static bool PauseGame = false;
    //public static bool GameInstruct = false;

    public GameObject pauseMenuUI;
    //public GameObject gameInstructUI;

    public GameObject pauseFirstButton;


    private void Awake()
    {
        //Instruct();
    }
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PressPause();
            }
    }

    public void PressPause()
    {
        if (PauseGame)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseGame = false;
        pauseMenuUI.SetActive(false);
        //GameInstruct = false;
        //gameInstructUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseGame = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(pauseFirstButton, null);
    }

    //void Instruct()
    //{
    //    GameInstruct = true;
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //    gameInstructUI.SetActive(true);
    //    Time.timeScale = 0f;
    //    EventSystem.current.SetSelectedGameObject(null);
    //    EventSystem.current.SetSelectedGameObject(tutorialFirstButton);
    //}

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
