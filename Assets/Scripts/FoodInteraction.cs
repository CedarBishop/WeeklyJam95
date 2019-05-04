using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public LayerMask whatIsFood;
    public float raycastLength = 1;
    public float spitTime = 3;
    public float peeTime = 10;
    [HideInInspector]public bool isSpoilingFood;

    private PlayerMovement playerMovement;
    private Text hintText;
    private Image waitingBarImage;
    private bool isNextToFood;    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        hintText = GameObject.Find("Hint Text").GetComponent<Text>();
        waitingBarImage = GameObject.Find("Waiting Bar Image").GetComponent<Image>();
        waitingBarImage.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastInAllDirections();
    }

    void RaycastInAllDirections ()
    {
        isNextToFood = Physics2D.Raycast(transform.position, Vector2.up, raycastLength, whatIsFood)
            || Physics2D.Raycast(transform.position, Vector2.down, raycastLength, whatIsFood)
            || Physics2D.Raycast(transform.position, Vector2.left, raycastLength, whatIsFood)
            || Physics2D.Raycast(transform.position, Vector2.right, raycastLength, whatIsFood);
        if (isNextToFood)
        {
            hintText.text = "Press Option To Spoil Food";
            if (Input.GetKeyDown(KeyCode.I))
            {
                StartCoroutine("CoSpitInFood");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine("CoPeeInFood");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {

            }
            else if (Input.GetKeyDown(KeyCode.L))
            {

            }
        }
        else
        {
            hintText.text = "";
        }   
    }

    IEnumerator CoSpitInFood()
    {
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (spitTime * 60));
            yield return null;
        }
        playerMovement.enabled = true;
        waitingBarImage.gameObject.SetActive(false);
    }

    IEnumerator CoPeeInFood ()
    {
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (peeTime * 60));
            yield return null;
        }
        playerMovement.enabled = true;
        waitingBarImage.gameObject.SetActive(false);
    }
}