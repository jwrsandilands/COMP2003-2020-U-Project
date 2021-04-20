using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SellingMenu : MonoBehaviour
{
    private int numberOfFishToSell = 0;

    public FishInventory fishInventory;

    int fishIndex;

    public Currency currencyManager;
    public FishManager fishManager;

    public Text numberText;
    public Text totalCostText;
    public Text shopNotification;


    private void OnBecameVisible()
    {
        shopNotification.enabled = false;
    }
    public void Increase()
    {
        if (numberOfFishToSell != fishInventory.fishes.Length )
        {
            numberOfFishToSell++;
            IncrementIndex();
            CalculateCost();
            numberText.text = numberOfFishToSell.ToString();
        }
        else
        {
            shopNotification.enabled = true;
            shopNotification.text = "You have reached your capacity limit";
        }
    }
    public void Decrease()
    {
        if (numberOfFishToSell > 0)
        {
            numberOfFishToSell--;
            CalculateCost();
            numberText.text = numberOfFishToSell.ToString();
        }
        else
        {
            shopNotification.enabled = true;
            shopNotification.text = "You cannot decrease the value below 0";
        }
    }

    private void IncrementIndex() 
    {
        if(fishIndex != 0)
        {
           fishIndex++;
        }
    }

    public void CalculateCost()
    {
        int totalCost = numberOfFishToSell * fishInventory.fishes[fishIndex].GetPrice();
        totalCostText.text = totalCost.ToString();
    }

    public void SellFish()
    {
        int size = fishInventory.fishes.Length;
        Array.Resize(ref fishInventory.fishes, size - numberOfFishToSell);
        fishManager.SubtractValue(numberOfFishToSell);
        currencyManager.SetCurrency(int.Parse(totalCostText.text));
        currencyManager.currencyText.text = currencyManager.GetCurrency().ToString();
        ResetValues();
        shopNotification.enabled = true;
        shopNotification.text = "Thanks for selling your fish";
    }

    private void ResetValues() 
    {
        numberOfFishToSell = 0;
        int totalcost = 0;
        numberText.text = numberOfFishToSell.ToString();
        totalCostText.text = totalcost.ToString();
    }

}