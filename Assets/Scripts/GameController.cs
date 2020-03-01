using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    //Text and Gameover
    public GameObject winPanel;
    public Text winText;
    public bool gameOver;
    

    public GameObject gameOverPanel;
    public Text gameOverText;

    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    public GameObject loseFirstButton, winFirstButton;

    public bool wonTheGame = false;


    [HideInInspector] public bool hasMacguffin;

    void Awake()
    {
        gameOver = false;
        //justDied = false;

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

        hasMacguffin = false;

        gameOverText.text = "";
        winText.text = "";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    void Update()
    {
        if (hasMacguffin == true && wonTheGame == false)
        {
            WinTheGame();
            wonTheGame = true;
        }
    }

    void WinTheGame()
    {
        winPanel.SetActive(true);
        winText.text = "You Win!";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.FindGameObjectWithTag("Guard").SetActive(false);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //IDK what's happening, but when you win, if the above two lines are on, nothing happens, and if they're commented out
        //when the music change happens it just becomes "zjzjzjzjzjzjzjzjzjzjzjz". It's not the music files themselves, I checked that.
        musicSource.Stop();
        musicSource.clip = winMusic;
        musicSource.Play();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(winFirstButton);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "GAME OVER!";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //justDied = true;
        //gameOverText.text = "Game Over!";
        //gameOver = true;
        GameObject.FindGameObjectWithTag("Guard").SetActive(false);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //This bit of work's just fine(again, when the above two lines are commented out, you're probably
        //already aware of the errors happening with that), IDK what's going on with the win music
        musicSource.Stop();
        musicSource.clip = loseMusic;
        musicSource.Play();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(loseFirstButton);
    }
}
