using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody2D playerRB;
    private Vector2 direction;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();   
    }
        
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRB.velocity = direction * speed * Time.deltaTime;
    }
}