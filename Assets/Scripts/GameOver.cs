using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;

    void Start ()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void OnGameOver ()
    {
        Time.timeScale = 0;
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
