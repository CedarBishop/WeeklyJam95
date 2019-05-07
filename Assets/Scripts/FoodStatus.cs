using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodStatus : MonoBehaviour
{
    public enum foodStatus { UnSpoilt, FlyDroppedOn, SpatOn, PeedOn, PooedOn, isBeingSpoiled };
    public foodStatus currentFoodStatus;
    [HideInInspector]public bool isReady;
    public SpriteRenderer spriteRenderer;

    private ScoreLogic scoreLogic;
    private FoodSpawner foodSpawner;
    private Transform headChefTransform;
    private FoodInteraction foodInteraction;
    private int spawnTransformIndex;
    //private bool isChangingColor;
    //private float timeToChange;
    //private Color colorToBe;
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
    }

    void Update ()
    {
        if (Vector3.Distance(transform.position,headChefTransform.position) < 3 && isReady == false && this.currentFoodStatus != foodStatus.isBeingSpoiled)
        {
            ReadyingFood();
        }
        //if (isChangingColor)
        //{
        //    spriteRenderer.color = Color.Lerp(spriteRenderer.color,colorToBe,1 / (timeToChange * 60) );
        //    isChangingColor = (spriteRenderer.color == colorToBe) ? false : true;
        //}
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
                spriteRenderer.color = Color.cyan;
                break;
            case 3:
                currentFoodStatus = foodStatus.PeedOn;
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                currentFoodStatus = foodStatus.PooedOn;
                spriteRenderer.color = new Color(200,120,50);
                break;
            case 5:
                currentFoodStatus = foodStatus.isBeingSpoiled;
                spriteRenderer.color = new Color(255, 255, 255);
                break;
            default:                
                break;                
        }
    }

    //public void ChangeFoodColor(int status)
    //{
    //    switch (status)
    //    {
    //        case 1:
    //            colorToBe = Color.grey;
    //            timeToChange = foodInteraction.dropFlyTime;
    //            isChangingColor = true;
    //            break;
    //        case 2:
    //            colorToBe = Color.cyan;
    //            timeToChange = foodInteraction.spitTime;
    //            isChangingColor = true;
    //            break;
    //        case 3:
    //            colorToBe = Color.yellow;
    //            timeToChange = foodInteraction.peeTime;
    //            isChangingColor = true;
    //            break;
    //        case 4:
    //            colorToBe = new Color(210, 105, 30);
    //            timeToChange = foodInteraction.pooTime;
    //            isChangingColor = true;
    //            break;
    //        case 5:
    //            currentFoodStatus = foodStatus.isBeingSpoiled;
    //            spriteRenderer.color = new Color(255, 255, 255);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}