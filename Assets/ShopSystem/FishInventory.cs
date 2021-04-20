using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInventory : MonoBehaviour
{
    public FishItem[] fishes;
    private int index;

    public bool isFull;

    public void AddToArray(FishItem fishElement)
    {
        if(index != fishes.Length)
        {
            fishes[index] = fishElement;
            index++;
        }
        else
        {
            isFull = true;
            Debug.Log("You cannot hold anymore fish");
        }
    }
}
