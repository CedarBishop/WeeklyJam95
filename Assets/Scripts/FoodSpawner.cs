using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform[] spawnLocations;
    public bool[] isLocationTaken;

    private int randomPosition;

    void Start ()
    {
        StartCoroutine("CoSpawnPlates");
    }

    IEnumerator CoSpawnPlates ()
    {
        while (true)
        {
            do
            {
                randomPosition = Random.Range(0, spawnLocations.Length);
            } while (isLocationTaken[randomPosition]);
            isLocationTaken[randomPosition] = true;
            GameObject clone = Instantiate(foodPrefab, spawnLocations[randomPosition].position,Quaternion.identity );
            clone.GetComponent<FoodStatus>().SpawnTransformIndex = randomPosition;
            float randomDelay = Random.Range(5,10);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    public void ClearSpawnLocation (int spawnIndex)
    {
        isLocationTaken[spawnIndex] = false;
    }
}
