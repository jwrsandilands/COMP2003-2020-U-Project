using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRod : MonoBehaviour
{
    
    public void ShowFishingRod(GameObject fishingRodPrefab)
    {
        fishingRodPrefab.SetActive(true); //enable visibility of the gameobject 
    }
}
