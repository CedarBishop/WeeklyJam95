using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public Image scoreImage;

    void Start()
    {
        scoreImage.fillAmount = 0;
    }

    public void AddToScore (int foodCondition)
    {
        Debug.Log("Invoking score");
        switch (foodCondition)
        {
            case 0:
                scoreImage.fillAmount -= 0.1f;
                break;
            case 1:
                scoreImage.fillAmount += 0.05f;
                Debug.Log("spit");
                break;
            case 2:
                scoreImage.fillAmount += 0.1f;
                break;
            case 3:
                scoreImage.fillAmount += 0.2f;
                break;
            case 4:
                scoreImage.fillAmount += 0.3f;
                break;
            default:
                
                break;
        }
    }
}
