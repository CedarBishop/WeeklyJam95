using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public AudioClip gameOverSFX;
    public AudioClip buttonSound;

    void Start ()
    {
        Time.timeScale = 1;
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void OnGameOver ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        gameOverCanvas.gameObject.SetActive(true);
        SoundManager.instance.PlaySFX(gameOverSFX);
    }

    public void RestartLevel()
    {
        SoundManager.instance.PlaySFX(buttonSound);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
