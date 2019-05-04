using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public float spitTime = 3;
    public float peeTime = 10;
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
                other.GetComponent<FoodStatus>().ChangeFoodStatus(1);
                StartCoroutine("CoSpitInFood");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                other.GetComponent<FoodStatus>().ChangeFoodStatus(2);
                StartCoroutine("CoPeeInFood");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                other.GetComponent<FoodStatus>().ChangeFoodStatus(3);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                other.GetComponent<FoodStatus>().ChangeFoodStatus(4);
            }
        }
        else
        {
            hintText.text = "";
        }   
    }

    IEnumerator CoSpitInFood()
    {
        isSpoilingFood = true;
        playerMovement.LockPlayerMovement();
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (spitTime * 60));
            yield return null;
        }
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    IEnumerator CoPeeInFood ()
    {
        isSpoilingFood = true;
        playerMovement.LockPlayerMovement();
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (peeTime * 60));
            yield return null;
        }
        playerMovement.enabled = true;
        isSpoilingFood = false; 
        waitingBarImage.gameObject.SetActive(false);
    }
}