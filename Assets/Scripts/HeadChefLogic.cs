using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadChefLogic : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 10;
    private Transform playerTransform;
    private int index = 0;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        }
        else
        {
            if (index < waypoints.Length - 1)
            {
                index++;
                GetDirectionToTarget();
            }
            else if (index == waypoints.Length - 1)
            {
                index = 0;
                GetDirectionToTarget();
            }            
        }
    }

    void GetDirectionToTarget ()
    {
        Vector2 direction = (waypoints[index].position - transform.position).normalized;
        if (direction.x < -0.5f)
        {
            anim.SetBool("facingUp", false);
            anim.SetBool("facingRight", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("facingLeft", true);
        }
        else if (direction.x > 0.5f)
        {
            anim.SetBool("facingUp", false);
            anim.SetBool("facingRight", true);
            anim.SetBool("facingDown", false);
            anim.SetBool("facingLeft", false);
        }
        else if (direction.y < -0.5f)
        {
            anim.SetBool("facingUp", false);
            anim.SetBool("facingRight", false);
            anim.SetBool("facingDown", true);
            anim.SetBool("facingLeft", false);
        }
        else if (direction.y > 0.5f)
        {
            anim.SetBool("facingUp", true);
            anim.SetBool("facingRight", false);
            anim.SetBool("facingDown", false);
            anim.SetBool("facingLeft", false);
        }
    }
}