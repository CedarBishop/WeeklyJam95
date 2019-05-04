﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadChefDetection : MonoBehaviour
{
    public float detectionRadius = 3;
    public LayerMask whatCanBeDetected;

    private GameOver gameOver;
    private FoodInteraction foodInteraction;
    private Transform player;
    private Image warningsImage;
    private bool canDetect;

    void Start()
    {
        canDetect = true;
        warningsImage = GameObject.Find("Warnings Image").GetComponent<Image>();
        warningsImage.fillAmount = 0;
        foodInteraction = GameObject.Find("Detection Trigger").GetComponent<FoodInteraction>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameOver = GameObject.Find("Scene Manager").GetComponent<GameOver>();
    }

    void Update()
    {
        if (warningsImage.fillAmount >= 1)
        {
            gameOver.OnGameOver();
        }
        else if (Vector3.Distance(transform.position, player.position) < detectionRadius && foodInteraction.isSpoilingFood && canDetect)
        {
            Vector3 targetDirection = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, detectionRadius, whatCanBeDetected);
            if (hit.collider.name == "Player")
            {  
                warningsImage.fillAmount += 0.333334f;
                canDetect = false;
                StartCoroutine("CoDetectCooldown");
            }          
        }        
    }

    IEnumerator CoDetectCooldown ()
    {
        yield return new WaitForSeconds(20);
        canDetect = true;
    }
}