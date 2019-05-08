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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetBool("facingLeft", true);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", true);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", true);
            playerAnim.SetBool("facingDown", false);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetBool("facingLeft", false);
            playerAnim.SetBool("facingRight", false);
            playerAnim.SetBool("facingUp", false);
            playerAnim.SetBool("facingDown", true);
        }
    }
}
