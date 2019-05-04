using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodStatus : MonoBehaviour
{
    public enum foodStatus { UnSpoilt, SpatOn, PeedOn, ThirdOption, FourthOption};
    public foodStatus currentFoodStatus;
    public bool isReady;
    public float timeTillReady;

    private SpriteRenderer spriteRenderer;
    private ScoreLogic scoreLogic;

    void Start ()
    {
        scoreLogic = GameObject.Find("Scene Manager").GetComponent<ScoreLogic>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isReady = false;
        StartCoroutine("ReadyingFood");
    }

    IEnumerator ReadyingFood ()
    {
        yield return new WaitForSeconds(timeTillReady);
        isReady = true;
        Debug.Log("finish coroutine");
        scoreLogic.AddToScore((int)currentFoodStatus);
    }

    public void ChangeFoodStatus (int status)
    {
        switch (status)
        {
            case 1:
                currentFoodStatus = foodStatus.SpatOn;
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                currentFoodStatus = foodStatus.PeedOn;
                spriteRenderer.color = Color.yellow;
                break;
            case 3:
                currentFoodStatus = foodStatus.ThirdOption;
                spriteRenderer.color = Color.black;
                break;
            case 4:
                currentFoodStatus = foodStatus.FourthOption;
                spriteRenderer.color = Color.green;
                break;
            default:
                break;
        }
    }
}