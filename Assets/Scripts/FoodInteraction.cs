using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public float spitTime = 3;
    public float dropFlyTime = 5;
    public float peeTime = 10;
    public float pooTime = 15;
    [HideInInspector]public bool isSpoilingFood;

    private PlayerMovement playerMovement;
    private Text hintText;
    private Image waitingBarImage;
    private bool isNextToFood;    

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        hintText = GameObject.Find("Hint Text").GetComponent<Text>();
        waitingBarImage = GameObject.Find("Waiting Bar Image").GetComponent<Image>();
        waitingBarImage.gameObject.SetActive(false);
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Food" && isSpoilingFood == false)
        { 
            hintText.text = "Press Option To Spoil Food";
            if (Input.GetKeyDown(KeyCode.I))
            {               
                StartCoroutine("CoSpitInFood",other);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine("CoDropFlyInFood",other);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                StartCoroutine("CoPeeInFood", other);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine("CoPooInFood", other);
            }
        }
        else
        {
            hintText.text = "";
        }   
    }

    IEnumerator CoSpitInFood(Collider2D other)
    {
        StartSpoiling();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (spitTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(1);
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    IEnumerator CoDropFlyInFood(Collider2D other)
    {
        StartSpoiling();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (dropFlyTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(2);
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    IEnumerator CoPeeInFood (Collider2D other)
    {
        StartSpoiling();        
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (peeTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(3);
        playerMovement.enabled = true;
        isSpoilingFood = false; 
        waitingBarImage.gameObject.SetActive(false);
    }

    IEnumerator CoPooInFood(Collider2D other)
    {
        StartSpoiling();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (pooTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(4);
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    void StartSpoiling ()
    {
        isSpoilingFood = true;
        playerMovement.LockPlayerMovement();
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
    }

    public void StopSpoiling ()
    {
        StopAllCoroutines();
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }
}