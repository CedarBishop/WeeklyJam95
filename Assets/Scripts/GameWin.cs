using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Canvas gameWinCanvas;
    public string nextLevel;
    public AudioClip victorySFX;
    public AudioClip buttonSound;

    private PauseLogic pauseLogic;
    void Start()
    {
        gameWinCanvas.gameObject.SetActive(false);
        pauseLogic = GetComponent<PauseLogic>();
    }

    public void OnGameWin ()
    {
        pauseLogic.CannotPause();
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
