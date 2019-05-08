using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string[] levelNames;
    public Canvas startCanvas;
    public Canvas levelSelectCanvas;
    public AudioClip buttonSound;

    void Start()
    {
        Time.timeScale = 1;
        startCanvas.gameObject.SetActive(true);
        levelSelectCanvas.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        startCanvas.gameObject.SetActive(false);
        levelSelectCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        Application.Quit();
    }

    public void LevelOne()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        SceneManager.LoadScene(levelNames[0]);
    }

    public void LevelTwo()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        SceneManager.LoadScene(levelNames[1]);
    }

    public void Return()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        startCanvas.gameObject.SetActive(true);
        levelSelectCanvas.gameObject.SetActive(false);
    }
}