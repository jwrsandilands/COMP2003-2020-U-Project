using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public GameObject[] fish; //this is for the amount of fish the Player has
    public GameObject[] inventory; //this is for the Player's inventory
    private int i = 0; //integer count for the for loop (Fish Array)
    private int j = 0; //integer count for the for loop (Inventory Array)

    public void AddToArray(GameObject arrayElement)
    {
        if(i != fish.Length) //if i does not equal the fish array length
        {
            fish[i] = arrayElement; //store the arrayElement in the fish array at element i
            i++; //increment i by 1
        }
        else
        {
            Debug.Log("You cannot hold anymore fish"); //show this message 
        }
    }

    public void AddToInventory(GameObject arrayElement)
    {
        if (j != inventory.Length) //if j does not equal the inventory length
        {
            inventory[j] = arrayElement; //store the arrayElement in the fish array at element j
            j++; //increment j by 1
        }
        else
        {
            Debug.Log("You cannot hold anymore items"); //show this message 
        }
    }
}