using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public float dropFlyTime = 3;
    public float spitTime = 5;
    public float peeTime = 10;
    public float pooTime = 15;
    public AudioClip[] spoilSFX;
    [HideInInspector]public bool isSpoilingFood;

    private PlayerMovement playerMovement;
    private FlyAmmoLogic flyAmmoLogic;
    private Text hintText;
    private Image waitingBarImage;
    private bool isNextToFood;    

    void Start()
    {
        flyAmmoLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<FlyAmmoLogic>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        hintText = GameObject.Find("Hint Text").GetComponent<Text>();
        waitingBarImage = GameObject.Find("Waiting Bar Image").GetComponent<Image>();
        waitingBarImage.gameObject.SetActive(false);
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Food" && isSpoilingFood == false && (other.GetComponent<FoodStatus>().currentFoodStatus == FoodStatus.foodStatus.UnSpoilt || other.GetComponent<FoodStatus>().currentFoodStatus == FoodStatus.foodStatus.isBeingSpoiled))
        { 
            hintText.text = "Press Option To Spoil Food";
            if (Input.GetKeyDown(KeyCode.I) && flyAmmoLogic.flyAmmoImage.fillAmount >= 0.25f)
            {
                flyAmmoLogic.UseFlyAmmo();
                SoundManager.instance.PlaySFX(spoilSFX[0]);
                StartCoroutine("CoDropFlyInFood", other);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                SoundManager.instance.PlaySFX(spoilSFX[1]);
                StartCoroutine("CoSpitInFood", other);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                SoundManager.instance.PlaySFX(spoilSFX[2]);
                StartCoroutine("CoPeeInFood", other);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                SoundManager.instance.PlaySFX(spoilSFX[3]);
                StartCoroutine("CoPooInFood", other);
            }
        }
        else
        {
            hintText.text = "";
        }
    }
    IEnumerator CoDropFlyInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
       // other.GetComponent<FoodStatus>().ChangeFoodColor(1);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (dropFlyTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(1);
        EndOfCoroutine();
    }

    IEnumerator CoSpitInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
       // other.GetComponent<FoodStatus>().ChangeFoodColor(2);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (spitTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(2);
        EndOfCoroutine();
    }

    

    IEnumerator CoPeeInFood (Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
        //other.GetComponent<FoodStatus>().ChangeFoodColor(3);
        StartOfCoroutine();        
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (peeTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(3);
        EndOfCoroutine();
    }

    IEnumerator CoPooInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
       // other.GetComponent<FoodStatus>().ChangeFoodColor(4);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (pooTime * 60));
            yield return null;
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(4);
        EndOfCoroutine();
    }

    void StartOfCoroutine ()
    {
        isSpoilingFood = true;
        playerMovement.LockPlayerMovement();
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
    }

    void EndOfCoroutine ( )
    {
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    public void StopSpoiling ()
    {
        StopAllCoroutines();
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }
}