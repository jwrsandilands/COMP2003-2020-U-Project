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

    GameObject selectedRod;
    GameObject selectedBait;
    GameObject selectedHook;
    GameObject[,] itemUis = new GameObject[4, 9];

    int[] currentItemIndex = {0, 0, 0};

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
        this.ChangeSelectedRod(itemUis[0, 0].GetComponent<ItemUI>().currentItem);
        this.ChangeSelectedBait(itemUis[1, 0].GetComponent<ItemUI>().currentItem);
        this.ChangeSelectedHook(itemUis[2, 0].GetComponent<ItemUI>().currentItem);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Switch(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Switch(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Switch(2);
        }
    }

    public void ChangeSelectedRod(GameObject newSelected)
    {
        Destroy(selectedRod);
        playerInventory.itemSelected = newSelected;
        selectedRod = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedRod.transform) as GameObject;
        selectedRod.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedRod.transform;
    }

    public void ChangeSelectedBait(GameObject newSelected)
    {
        Destroy(selectedBait);
        playerInventory.itemSelected = newSelected;
        selectedBait = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedBait.transform) as GameObject;
        selectedBait.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedBait.transform;
    }

    public void ChangeSelectedHook(GameObject newSelected)
    {
        Destroy(selectedHook);
        playerInventory.itemSelected = newSelected;
        selectedHook = Instantiate(newSelected.GetComponent<InventoryItemHolder>().invIcon, selectedUI.GetComponent<InventorySelected>().SelectedHook.transform) as GameObject;
        selectedHook.transform.parent = selectedUI.GetComponent<InventorySelected>().SelectedHook.transform;
    }

    public void AddRod()
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

    private void Switch(int index)
    {
        currentItemIndex[index] += 1;
        if (currentItemIndex[index] == 9)
        {
            currentItemIndex[index] = 0;
        }
        if (itemUis[index, currentItemIndex[index]].GetComponent<ItemUI>().isItem == false)
        {
            currentItemIndex[index] = 0;
        }

        if (index == 0)
        {
            this.ChangeSelectedRod(itemUis[index, currentItemIndex[index]].GetComponent<ItemUI>().currentItem);
        }
        else if (index == 1)
        {
            this.ChangeSelectedBait(itemUis[index, currentItemIndex[index]].GetComponent<ItemUI>().currentItem);
        }
        else 
        {
            this.ChangeSelectedHook(itemUis[index, currentItemIndex[index]].GetComponent<ItemUI>().currentItem);
        }
    }

}
