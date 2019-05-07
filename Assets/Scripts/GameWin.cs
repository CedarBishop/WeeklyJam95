using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Canvas gameWinCanvas;
    public string nextLevel;
    public AudioClip victorySFX;
    void Start()
    {
        gameWinCanvas.gameObject.SetActive(false);
    }

    public void OnGameWin ()
    {
        SoundManager.instance.PlaySFX(victorySFX);
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
