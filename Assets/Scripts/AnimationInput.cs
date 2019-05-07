using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    private Animator playerAnim;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerAnim.SetBool("facingLeft", true);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", true);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", true);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", true);
        }
    }
}
