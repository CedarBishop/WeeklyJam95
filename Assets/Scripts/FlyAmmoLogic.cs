using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class FlyAmmoLogic : MonoBehaviour
{
    public Image flyAmmoImage;
    public float timeTillReactivation = 5;

    void Start()
    {
        flyAmmoImage.fillAmount = 1;
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Fly" && flyAmmoImage.fillAmount < 1)
        {
            flyAmmoImage.fillAmount += 0.25f;
            other.gameObject.SetActive(false);
            StartCoroutine("CoReActivateFly", other);
        }
    }

    IEnumerator CoReActivateFly (Collider2D other)
    {
        int randomIndex = Random.Range(0, other.GetComponent<FlyMovement>().waypoints.Length);
        other.gameObject.transform.position = other.GetComponent<FlyMovement>().waypoints[randomIndex].position;
        yield return new WaitForSeconds(timeTillReactivation);
        other.gameObject.SetActive(true);
    }

    public void UseFlyAmmo ()
    {
        flyAmmoImage.fillAmount -= 0.25f;
    }
}
