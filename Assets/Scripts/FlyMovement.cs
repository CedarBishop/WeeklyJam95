using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    private int index = 0;
    private SpriteRenderer spriteRenderer;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].position) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,waypoints[index].position,speed * Time.deltaTime);
        }
        else
        {
            index = Random.Range(0,waypoints.Length);            
            Vector2 direction = (waypoints[index].position - transform.position).normalized;
            spriteRenderer.flipX = (direction.x > 0.5f) ? true : false;           
        }
    }
}