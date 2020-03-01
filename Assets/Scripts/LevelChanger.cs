using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        StartCoroutine("Wait");

        if (SceneManager.GetActiveScene().name == "TeamBeachBod")
        {
            Wait();
        }
        else if (SceneManager.GetActiveScene().name == "Instructions")
        {
            Debug.Log("On Instruct. Screen. Resetting Time and Stopping Coroutine.");
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
            StopCoroutine("Wait");
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    FadeToLevelButton();
            //}
        }
        else
        {
            StopCoroutine("Wait");
            Debug.Log("Stopping Coroutine");
            //StopCoroutine("resetWait");
        }
    }

    //void Update()
    //{
    //    if (SceneManager.GetActiveScene().name == "TeamBeachBod")
    //    {
    //        Wait();
    //    }

    //    //else if (SceneManager.GetActiveScene().name == "Menu")
    //    //{
    //    //    if (OnFadeComplete != active)
    //    //    {
    //    //        fadeIn();
    //    //    }
    //    //}

    //    else if (SceneManager.GetActiveScene().name == "Instructions")
    //    {
    //        if (Time.timeScale == 0f)
    //        {
    //            Time.timeScale = 1f;
    //        }
    //        //if (Input.GetButtonDown("Fire1"))
    //        //{
    //        //    FadeToLevelButton();
    //        //}
    //    }

    //    else
    //    {
    //        StopCoroutine("Wait");
    //        Debug.Log("Stopping Coroutine");
    //        //StopCoroutine("resetWait");
    //    }
    //}

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        FadeToLevel(1);
    }

    public void FadeToLevelButton()
    {
        FadeToLevel(1);
    }

}
