using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    //public AudioSource soundSource;
    //public AudioClip blipSound;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        //soundSource.clip = blipSound;
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    public void PlayGame()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}