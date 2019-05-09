using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public Canvas pauseCanvas;
    public string sceneName;
    public AudioClip buttonClickSFX;

    private AnimationInput animationInput;
    private bool canPause;

    void Start()
    {
        canPause = true;
        pauseCanvas.gameObject.SetActive(false);
        animationInput = GameObject.Find("Player").GetComponent<AnimationInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.gameObject.activeSelf && canPause)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas.gameObject.activeSelf == false && canPause)
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
        animationInput.enabled = true;
    }

    public void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SoundManager.instance.PlaySFX(buttonClickSFX);
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        animationInput.enabled = false;
    }

    public void MainMenu()
    {
        SoundManager.instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene(sceneName);
    }

    public void CannotPause ()
    {
        canPause = false;
    }
}
