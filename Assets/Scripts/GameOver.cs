using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName;

    public void OnGameOver ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
