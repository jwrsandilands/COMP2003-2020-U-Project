using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public GameObject itemUI;
    public GameObject gridLayout;
    public GameObject noItemIcon;
    public GameObject selectedUI;
    GameObject selectedItem;
    GameObject[] itemUIs = new GameObject[9];
    int currentItemIndex = 0;

    private void Start()
    {
        GameObject[] tempInventory = playerInventory.inventory.GetItems();
        for (int i = 0; i < itemUIs.Length; i++)
        {
            itemUIs[i] = Instantiate(itemUI) as GameObject;
            itemUIs[i].transform.parent = gridLayout.transform;
            if (tempInventory[i] == null)
            {
                itemUIs[i].GetComponent<ItemUI>().currentItem = noItemIcon;
                itemUIs[i].GetComponent<ItemUI>().Draw(true);
            }
            else
            {
                itemUIs[i].GetComponent<ItemUI>().currentItem = tempInventory[i]; //.GetComponent<Hook>().invIcon;
                itemUIs[i].GetComponent<ItemUI>().Draw(false);
            }
        }
        this.ChangeSelected(itemUIs[0].GetComponent<ItemUI>().currentItem);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Switch();
        }
    }

    public void ChangeSelected(GameObject newSelected) 
    {
        Destroy(selectedItem);
        playerInventory.itemSelected = newSelected;
        selectedItem = Instantiate(newSelected.GetComponent<Rod>().invIcon, selectedUI.transform) as GameObject;
        selectedItem.transform.parent = selectedUI.transform;
    }

    public void AddItem() 
    {
        GameObject[] tempUI = GameObject.FindGameObjectsWithTag("ItemUI");
        foreach (GameObject obj in tempUI) 
        {
            Destroy(obj);
        }

        GameObject[] tempInventory = playerInventory.inventory.GetItems();
        for (int i = 0; i < itemUIs.Length; i++)
        {
            itemUIs[i] = Instantiate(itemUI) as GameObject;
            itemUIs[i].transform.parent = gridLayout.transform;
            if (tempInventory[i] == null)
            {
                itemUIs[i].GetComponent<ItemUI>().currentItem = noItemIcon;
                itemUIs[i].GetComponent<ItemUI>().Draw(true);
            }
            else
            {
                itemUIs[i].GetComponent<ItemUI>().currentItem = tempInventory[i]; //.GetComponent<Hook>().invIcon;
                itemUIs[i].GetComponent<ItemUI>().Draw(false);
            }
        }
    }

    private void Switch()
    {
        currentItemIndex += 1;
        if (currentItemIndex == 9)
        {
            currentItemIndex = 0;
        }
        if (itemUIs[currentItemIndex].GetComponent<ItemUI>().isItem == false) 
        {
            currentItemIndex = 0;
        }
        this.ChangeSelected(itemUIs[currentItemIndex].GetComponent<ItemUI>().currentItem);
    }

}
