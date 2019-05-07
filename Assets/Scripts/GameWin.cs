using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Canvas gameWinCanvas;
    public string nextLevel;
    void Start()
    {
        gameWinCanvas.gameObject.SetActive(false);
    }

    public void OnGameWin ()
    {
        Time.timeScale = 0;
        gameWinCanvas.gameObject.SetActive(true);
    }

    public void NextLevel ()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
