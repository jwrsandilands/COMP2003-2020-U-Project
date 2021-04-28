using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    [Header("Needed Gameobjects")]
    public GameObject itemUI;
    public GameObject noItemIcon;
    public GameObject selectedUI;

    [Header("Grid Layouts")]
    public GameObject[] gridLayouts = new GameObject[4];

    GameObject selectedItem;
    GameObject[,] itemUis = new GameObject[4, 9];

    //GameObject[] rodsItemUis = new GameObject[9];
    //GameObject[] baitsItemUis = new GameObject[9];
    //GameObject[] hooksItemUis = new GameObject[9];
    //GameObject[] fishItemUis = new GameObject[9];

    int currentItemIndex = 0;

    private void Start()
    {
        GameObject[] tempInventory;

        for (int i = 0; i < itemUis.GetLength(0); i++)
        {
            if (i == 0)
            {
                tempInventory = playerInventory.inventory.GetRods();
            }
            else if (i == 1) 
            { 
                tempInventory = playerInventory.inventory.GetBait(); 
            }
            else if (i == 2) 
            { 
                tempInventory = playerInventory.inventory.GetHooks(); 
            }
            else 
            { 
                tempInventory = playerInventory.inventory.GetFish(); 
            }
            for (int j = 0; j < itemUis.GetLength(1); j++)
            {
                itemUis[i, j] = Instantiate(itemUI) as GameObject;
                itemUis[i, j].transform.parent = gridLayouts[i].transform;
                if (tempInventory[j] == null)
                {
                    itemUis[i, j].GetComponent<ItemUI>().currentItem = noItemIcon;
                    itemUis[i, j].GetComponent<ItemUI>().Draw(true);
                }
                else
                {
                    itemUis[i, j].GetComponent<ItemUI>().currentItem = tempInventory[j]; //.GetComponent<Hook>().invIcon;
                    itemUis[i, j].GetComponent<ItemUI>().Draw(false);
                }
            }
        }
        this.ChangeSelected(itemUis[0, 0].GetComponent<ItemUI>().currentItem);

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
        selectedItem = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.transform) as GameObject;
        selectedItem.transform.parent = selectedUI.transform;
    }

    public void AddItem()
    {
        GameObject[] tempUI = GameObject.FindGameObjectsWithTag("ItemUI");
        foreach (GameObject obj in tempUI)
        {
            Destroy(obj);
        }

        GameObject[] tempInventory = playerInventory.inventory.GetRods();
        for (int i = 0; i < itemUis.GetLength(1); i++)
        {
            itemUis[0, i] = Instantiate(itemUI) as GameObject;
            itemUis[0, i].transform.parent = gridLayouts[i].transform;
            if (tempInventory[i] == null)
            {
                itemUis[0, i].GetComponent<ItemUI>().currentItem = noItemIcon;
                itemUis[0, i].GetComponent<ItemUI>().Draw(true);
            }
            else
            {
                itemUis[0, i].GetComponent<ItemUI>().currentItem = tempInventory[i]; //.GetComponent<Hook>().invIcon;
                itemUis[0, i].GetComponent<ItemUI>().Draw(false);
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
        if (itemUis[0, currentItemIndex].GetComponent<ItemUI>().isItem == false)
        {
            currentItemIndex = 0;
        }
        this.ChangeSelected(itemUis[0, currentItemIndex].GetComponent<ItemUI>().currentItem);
    }

}
