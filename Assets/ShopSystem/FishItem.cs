using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishItem : MonoBehaviour
{
    private int fishValue;
    private int fishPrice = 25;
    private FishManager manager;
    private FishInventory inventory;

    [SerializeField]
    public Image fishImage;

    private void Start()
    {
        manager = FindObjectOfType<FishManager>();
        inventory = FindObjectOfType<FishInventory>();
    }

    public int GetValue()
    {
        return fishValue;
    }

    public int GetPrice()
    {
        return fishPrice;
    }

    public void SetValue(int inValue)
    {
        fishValue = inValue;
    }

    public Image GetImage()
    {
        return fishImage;
    }


    public void Collect()
    {
        if (inventory.isFull != true) 
        {
            manager.AddValue();
            gameObject.SetActive(false);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
       // if (other.CompareTag("Character"))
       // {
        //    manager.AddValue();
        //    gameObject.SetActive(false);
        //}
    //}
}
