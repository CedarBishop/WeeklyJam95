using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodStatus : MonoBehaviour
{
    public enum foodStatus { UnSpoilt, SpatOn, FlyDroppedOn , PeedOn, PooedOn };
    public foodStatus currentFoodStatus;
    public bool isReady;
    public float timeTillReady;

    private SpriteRenderer spriteRenderer;
    private ScoreLogic scoreLogic;
    private int spawnTransformIndex;
    private FoodSpawner foodSpawner;

    public int SpawnTransformIndex 
    {
        set { spawnTransformIndex = value; }
    }

    void Start ()
    {
        foodSpawner = GameObject.Find("Scene Manager").GetComponent<FoodSpawner>();
        scoreLogic = GameObject.Find("Scene Manager").GetComponent<ScoreLogic>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isReady = false;
        StartCoroutine("ReadyingFood");
    }

    IEnumerator ReadyingFood ()
    {
        yield return new WaitForSeconds(timeTillReady);
        isReady = true;
        scoreLogic.AddToScore((int)currentFoodStatus);
        foodSpawner.ClearSpawnLocation(spawnTransformIndex);
        Destroy(gameObject);
    }

    public void ChangeFoodStatus (int status)
    {
        switch (status)
        {
            case 1:
                currentFoodStatus = foodStatus.SpatOn;
                spriteRenderer.color = Color.cyan;
                break;
            case 2:
                currentFoodStatus = foodStatus.FlyDroppedOn;
                spriteRenderer.color = new Color(10,10,10); ;
                break;
            case 3:
                currentFoodStatus = foodStatus.PeedOn;
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                currentFoodStatus = foodStatus.PooedOn;
                spriteRenderer.color = new Color(210,105,30);
                break;
            default:
                break;
        }
    }
}