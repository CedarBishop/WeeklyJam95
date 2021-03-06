﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public float dropFlyTime = 3;
    public float spitTime = 5;
    public float peeTime = 10;
    public float pooTime = 15;
    public AudioClip[] spoilSFX;
    public Image hintImage;
    [HideInInspector]public bool isSpoilingFood;

    private PlayerMovement playerMovement;
    private FlyAmmoLogic flyAmmoLogic;
    private AnimationInput animationInput;
    private Image waitingBarImage;
    private bool isNextToFood;
    private bool forcedStop;

    void Start()
    {
        animationInput = GameObject.Find("Player").GetComponent<AnimationInput>();
        flyAmmoLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<FlyAmmoLogic>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        waitingBarImage = GameObject.Find("Waiting Bar Image").GetComponent<Image>();
        waitingBarImage.gameObject.SetActive(false);
        hintImage.gameObject.SetActive(false);
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Food" && isSpoilingFood == false && (other.GetComponent<FoodStatus>().currentFoodStatus == FoodStatus.foodStatus.UnSpoilt || other.GetComponent<FoodStatus>().currentFoodStatus == FoodStatus.foodStatus.isBeingSpoiled))
        {
            hintImage.gameObject.SetActive(true);
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
            hintImage.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Food" && forcedStop)
        {
            forcedStop = false;
            Destroy(other.gameObject);
        }
    }
    IEnumerator CoDropFlyInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (dropFlyTime / Time.deltaTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(1);
        EndOfCoroutine();
    }

    IEnumerator CoSpitInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (spitTime / Time.deltaTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(2);
        EndOfCoroutine();
    }

    

    IEnumerator CoPeeInFood (Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
        StartOfCoroutine();        
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 /(peeTime / Time.deltaTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(3);
        EndOfCoroutine();
    }

    IEnumerator CoPooInFood(Collider2D other)
    {
        other.GetComponent<FoodStatus>().ChangeFoodStatus(5);
        StartOfCoroutine();
        while (waitingBarImage.fillAmount > 0)
        {
            waitingBarImage.fillAmount -= (1 / (pooTime / Time.deltaTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        other.GetComponent<FoodStatus>().ChangeFoodStatus(4);
        EndOfCoroutine();
    }

    void StartOfCoroutine ()
    {
        isSpoilingFood = true;
        animationInput.enabled = false;
        playerMovement.LockPlayerMovement();
        playerMovement.enabled = false;
        waitingBarImage.gameObject.SetActive(true);
        waitingBarImage.fillAmount = 1;
    }

    void EndOfCoroutine ( )
    {
        animationInput.enabled = true;
        playerMovement.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }

    public void StopSpoiling ()
    {
        StopAllCoroutines();
        forcedStop = true;
        playerMovement.enabled = true;
        animationInput.enabled = true;
        isSpoilingFood = false;
        waitingBarImage.gameObject.SetActive(false);
    }
}