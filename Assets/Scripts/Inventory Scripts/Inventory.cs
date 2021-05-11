using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public static Inventory instance;
    public int stackLimit;

    public GameObject[] rods = new GameObject[9];
    public GameObject[] bait = new GameObject[9];
    public GameObject[] hooks = new GameObject[9];
    public GameObject[] reels = new GameObject[9];
    public GameObject[] fish = new GameObject[9];

    void start()
    {
        instance = this;
    }
    public Inventory() 
    { 
        
    }

    public GameObject[] GetRods() 
    {
        return rods;
    }
    public GameObject[] GetBait()
    {
        return bait;
    }
    public GameObject[] GetHooks()
    {
        return hooks;
    }
    public GameObject[] GetFish()
    {
        return fish;
    }

    public GameObject[] GetReels()
    {
        return reels;
    }

    //public void AddItem(GameObject newItem) 
    //{
    //    int nextNullItemSlot = -1;
    //    for (int n = 0; n < rods.Length; n++) 
    //    {        
    //        if (rods[n] == null) 
    //        {
    //            nextNullItemSlot = n;
    //            break;
    //        }
    //    }
    //    if (nextNullItemSlot != -1) 
    //    {
    //        rods[nextNullItemSlot] = newItem;
    //    }
    //}

    public void AddFish(GameObject newFish)
    {
        newFish.GetComponentInChildren<SpriteRenderer>().enabled = false;
        newFish.GetComponent<FlockAgent>().enabled = false;
        newFish.GetComponent<MoveTowardsHook>().enabled = false;

        int nextNullItemSlot = -1;
        for (int n = 0; n < fish.Length; n++)
        {
            if (fish[n] == null)
            {
                nextNullItemSlot = n;
                break;
            }
            else 
            {
                if (fish[n].GetComponent<Fish>().fishName == newFish.GetComponent<Fish>().fishName) 
                {
                    if (!(fish[n].GetComponent<Fish>().stackLevel == stackLimit))
                    {
                        fish[n].GetComponent<Fish>().stackLevel += 1;
                        nextNullItemSlot = -1;
                        break;
                    }
                }
            }
        }
        if (nextNullItemSlot != -1)
        {
            fish[nextNullItemSlot] = newFish;
        }
    }
}
