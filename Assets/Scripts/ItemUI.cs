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

    private void Start()
    {
        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }

    public void Draw(bool isNothing) 
    {
        if (!isNothing)
        {
            icon = Instantiate(currentItem.GetComponent<InventoryItemHolder>().invIcon, gameObject.transform) as GameObject;
            isItem = true;
        }
        else 
        {
            icon = Instantiate(currentItem, gameObject.transform) as GameObject;
            isItem = false;
        }
        icon.transform.parent = gameObject.transform;
        icon.transform.SetAsFirstSibling();
    }

    public void OnSelected()
    {
        InventoryManager.ChangeSelected(currentItem);
    }
}
