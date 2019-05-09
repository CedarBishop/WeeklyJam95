using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public Canvas pauseCanvas;
    public string sceneName;
    public AudioClip buttonClickSFX;

    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.gameObject.activeSelf)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.gameObject.activeSelf == false)
        {
            Pause();
        }
    }

    public void Resume ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SoundManager.instance.PlaySFX(buttonClickSFX);
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SoundManager.instance.PlaySFX(buttonClickSFX);
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SoundManager.instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene(sceneName);
    }
}
