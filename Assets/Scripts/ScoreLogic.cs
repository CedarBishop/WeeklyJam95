using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public Image scoreImage;
    public Text reviewText;
    public Transform startPoint;
    public Transform endPoint;
    public float textSpeed = 1;
    public string[] reviews = new string[5];
    [Range(-1,1)]public float[] scores = new float[5];

    private GameWin gameWin;

    void Start()
    {
        gameWin = GetComponent<GameWin>();
        reviewText.text = "";
        scoreImage.fillAmount = 0;
    }

    public void AddToScore (int foodCondition)
    {
        reviewText.text = reviews[foodCondition];
        scoreImage.fillAmount += scores[foodCondition];       
        StartCoroutine("ResetText");
        CheckIfGameIsWon();
    }

    IEnumerator ResetText ()
    {
        reviewText.transform.position = startPoint.position;
        while (reviewText.transform.position != endPoint.position)
        {
            reviewText.transform.position = Vector3.MoveTowards(reviewText.transform.position,endPoint.position, textSpeed * Time.deltaTime);
            yield return null;
        }
        reviewText.text = "";
    }

    void CheckIfGameIsWon ()
    {
        if (scoreImage.fillAmount == 1)
        {
            gameWin.OnGameWin();
        }
    }
}
