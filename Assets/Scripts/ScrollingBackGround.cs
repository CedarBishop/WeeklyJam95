using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public GameObject[] tileMaps;
    public Transform spawnPoint;
    public Transform endPoint;
    public float scrollingSpeed = 1;

    void Update()
    {
        foreach (GameObject tileMap in tileMaps)
        {
            tileMap.transform.Translate(new Vector3(1,1,0) * scrollingSpeed * Time.deltaTime);
            if (tileMap.transform.position.y > endPoint.transform.position.y)
            {
                tileMap.transform.position = spawnPoint.position;
            }
        }
    }
}