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
                spriteRenderer.color = new Color(0,0.5f,1.0f);
                break;
            case 3:
                currentFoodStatus = foodStatus.PeedOn;
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                currentFoodStatus = foodStatus.PooedOn;
                spriteRenderer.color = new Color(0.8f,0.5f,0.1f);
                break;
            case 5:
                currentFoodStatus = foodStatus.isBeingSpoiled;
                spriteRenderer.color = new Color(1, 1, 1);
                break;
            default:                
                break;                
        }
    }
}