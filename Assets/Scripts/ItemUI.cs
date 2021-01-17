using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [System.NonSerialized] public GameObject currentItem;
    [System.NonSerialized] public GameObject icon;
    public GameObject button;
    InventoryManager InventoryManager;

    private void Start()
    {
        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }

    public void Draw(bool isNothing) 
    {
        if (!isNothing)
        {
            icon = Instantiate(currentItem.GetComponent<Hook>().invIcon, gameObject.transform) as GameObject;
            button.SetActive(true);
        }
        else 
        {
            icon = Instantiate(currentItem, gameObject.transform) as GameObject;
            button.SetActive(false);
        }
        icon.transform.parent = gameObject.transform;
        icon.transform.SetAsFirstSibling();
    }

    public void OnSelected()
    {
        InventoryManager.ChangeSelected(currentItem);
    }
}
