using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [System.NonSerialized] public GameObject currentItem;
    [System.NonSerialized] public GameObject icon;
    InventoryManager InventoryManager;
    [System.NonSerialized] public bool isItem = false;
    public GameObject buttonObject;
    [System.NonSerialized] public int type;

    private void Start()
    {
        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }

    public void Draw(bool isNothing, int inputType) 
    {
        type = inputType;
        if (!isNothing)
        {
            icon = Instantiate(currentItem.GetComponent<InventoryItemHolder>().invIcon, gameObject.transform) as GameObject;
            isItem = true;
        }
        else 
        {
            icon = Instantiate(currentItem, gameObject.transform) as GameObject;
            isItem = false;
            buttonObject.SetActive(false);
        }
        icon.transform.parent = gameObject.transform;
        icon.transform.SetAsFirstSibling();
    }

    public void OnSelected()
    {
        if (type == 0)
        {
            InventoryManager.ChangeSelectedRod(currentItem);
        }
        else if (type == 1)
        {
            InventoryManager.ChangeSelectedBait(currentItem);
        }
        else if (type == 2)
        {
            InventoryManager.ChangeSelectedHook(currentItem);
        }
        else 
        {
            InventoryManager.ChangeSelectedReel(currentItem);
        }

    }
}
