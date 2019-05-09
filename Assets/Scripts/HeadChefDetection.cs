using UnityEngine;
using UnityEngine.UI;

public class HeadChefDetection : MonoBehaviour
{
    public float detectionRadius = 3;
    public LayerMask whatCanBeDetected;
    public AudioClip DetectionSFX;

    private GameOver gameOver;
    private FoodInteraction foodInteraction;
    private Transform player;
    private Image warningsImage;
    private bool gameHasEnded;

    void Start()
    {
        gameHasEnded = false;
        warningsImage = GameObject.Find("Warnings Image").GetComponent<Image>();
        warningsImage.fillAmount = 0;
        foodInteraction = GameObject.Find("Detection Trigger").GetComponent<FoodInteraction>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameOver = GameObject.Find("Scene Manager").GetComponent<GameOver>();
    }

    void Update()
    {
        if (warningsImage.fillAmount >= 1 && gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOver.OnGameOver();
        }
        else if (Vector3.Distance(transform.position, player.position) < detectionRadius && foodInteraction.isSpoilingFood)
        {
            Vector3 targetDirection = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, detectionRadius, whatCanBeDetected);
            if (hit.collider.name == "Player")
            {
                SoundManager.instance.PlaySFX(DetectionSFX);
                warningsImage.fillAmount += 0.333334f;
                foodInteraction.StopSpoiling();
            }          
        }        
    }

   
}