using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodStatus : MonoBehaviour
{
    public enum foodStatus { UnSpoilt, SpatOn,PeedOn, ThirdOption, FourthOption};
    public foodStatus currentFoodStatus;
    public bool isReady;
    public float timeTillReady;

    IEnumerator ReadyingFood ()
    {
        yield return new WaitForSeconds(timeTillReady);
    }
}
