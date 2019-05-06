using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    private int index = 0;
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,waypoints[index].position,speed * Time.deltaTime);
        }
        else
        {
            index = Random.Range(0,waypoints.Length);
        }
    }
}