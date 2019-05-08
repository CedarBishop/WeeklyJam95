using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadChefLogic : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 10;
    private Transform playerTransform;
    private int index = 0;
    void Start()
    {
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
            // add anim set bool left here
            print(gameObject.name + " is going left");
        }
        else if (direction.x > 0.5f)
        {
            // add anim set bool right here
            print(gameObject.name + " is going right");
        }
        else if (direction.y < -0.5f)
        {
            // add anim set bool down here
            print(gameObject.name + " is going down");
        }
        else if (direction.y > 0.5f)
        {
            // add anim set bool up here
            print(gameObject.name + " is going up");
        }
    }
}