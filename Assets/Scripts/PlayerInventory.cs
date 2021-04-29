using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    [System.NonSerialized] public GameObject itemSelected;
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
