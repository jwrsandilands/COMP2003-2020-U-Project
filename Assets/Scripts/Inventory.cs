using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public GameObject[] items = new GameObject[9];

    public Inventory() 
    { 
        
    }

    public GameObject[] GetItems() 
    {
        return items;
    }

    public void AddItem(GameObject newItem) 
    {
        int nextNullItemSlot = -1;
        for (int n = 0; n < items.Length; n++) 
        {        
            if (items[n] == null) 
            {
                nextNullItemSlot = n;
                break;
            }
        }
        if (nextNullItemSlot != -1) 
        {
            items[nextNullItemSlot] = newItem;
        }
    }
}
