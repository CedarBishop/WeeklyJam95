using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodStatus : MonoBehaviour
{
    public enum foodStatus { UnSpoilt, FlyDroppedOn, SpatOn, PeedOn, PooedOn, isBeingSpoiled };
    public foodStatus currentFoodStatus;
    [HideInInspector]public bool isReady;

    private SpriteRenderer spriteRenderer;
    private ScoreLogic scoreLogic;
    private int spawnTransformIndex;
    private FoodSpawner foodSpawner;
    private Transform headChefTransform;
    private FoodInteraction foodInteraction;

    public int SpawnTransformIndex 
    {
        set { spawnTransformIndex = value; }
    }

    void Start ()
    {
        headChefTransform = GameObject.Find("Head Chef").GetComponent<Transform>();
        foodSpawner = GameObject.Find("Scene Manager").GetComponent<FoodSpawner>();
        scoreLogic = GameObject.Find("Scene Manager").GetComponent<ScoreLogic>();
        foodInteraction = GameObject.Find("Detection Trigger").GetComponent<FoodInteraction>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        if (Vector3.Distance(transform.position,headChefTransform.position) < 2 && isReady == false && currentFoodStatus  != foodStatus.isBeingSpoiled)
        {
            ReadyingFood();
        }
        else if (Vector3.Distance(transform.position, headChefTransform.position) < 2 && isReady == false && currentFoodStatus == foodStatus.isBeingSpoiled)
        {
            foodInteraction.StopSpoiling();
        }
    }

    void ReadyingFood ()
    {
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
                currentFoodStatus = foodStatus.FlyDroppedOn;
                spriteRenderer.color = Color.grey;
                break;
            case 2:
                currentFoodStatus = foodStatus.SpatOn;
                spriteRenderer.color = Color.cyan; ;
                break;
            case 3:
                currentFoodStatus = foodStatus.PeedOn;
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                currentFoodStatus = foodStatus.PooedOn;
                spriteRenderer.color = new Color(210,105,30);
                break;
            case 5:
                currentFoodStatus = foodStatus.isBeingSpoiled;
                spriteRenderer.color = new Color(255, 255, 255);
                break;
            default:                
                break;                
        }
    }
}