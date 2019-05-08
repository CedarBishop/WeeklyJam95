using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string[] levelNames;
    public Canvas startCanvas;
    public Canvas levelSelectCanvas;

    void Start()
    {
        Time.timeScale = 1;
        startCanvas.gameObject.SetActive(true);
        levelSelectCanvas.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        startCanvas.gameObject.SetActive(false);
        levelSelectCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(levelNames[0]);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(levelNames[1]);
    }

    public void Return()
    {
        startCanvas.gameObject.SetActive(true);
        levelSelectCanvas.gameObject.SetActive(false);
    }
}