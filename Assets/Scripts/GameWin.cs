using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Canvas gameWinCanvas;
    public string nextLevel;
    public AudioClip victorySFX;
    public AudioClip buttonSound;
    void Start()
    {
        gameWinCanvas.gameObject.SetActive(false);
    }

    public void OnGameWin ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SoundManager.instance.PlaySFX(victorySFX);
        Time.timeScale = 0;
        gameWinCanvas.gameObject.SetActive(true);
    }

    public void NextLevel ()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        SceneManager.LoadScene(nextLevel);
    }

    public void MainMenu ()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        SceneManager.LoadScene("MainMenu");
    }
}
