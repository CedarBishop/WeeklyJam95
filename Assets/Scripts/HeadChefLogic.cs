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
            }
            else if (index == waypoints.Length - 1)
            {
                index = 0;
            }
        }
    }
}
