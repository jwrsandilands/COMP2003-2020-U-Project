using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    [System.NonSerialized] public GameObject rodSelected;
    [System.NonSerialized] public GameObject baitSelected;
    [System.NonSerialized] public GameObject hookSelected;
    [System.NonSerialized] public GameObject reelSelected;
    public InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject pickUp = other.gameObject;
        if (other.tag == "Item")
        {
            inventory.AddItem(pickUp);
        }
        inventoryManager.AddRod();
    }
}
