using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishManager : MonoBehaviour
{
    private int value;

    private FishItem fish;
    public Text valueText;

    public FishInventory inventory;


    private void Start()
    {
        fish = FindObjectOfType<FishItem>();
    }

    public void AddValue()
    {
        value++;
        Debug.Log(value);
        fish.SetValue(value);
        valueText.text = fish.GetValue().ToString();
        inventory.AddToArray(fish);
    }

    public void SubtractValue(int subValue)
    {
        value = value - subValue;
        Debug.Log(value);
        fish.SetValue(value);
        valueText.text = fish.GetValue().ToString();
    }
}
