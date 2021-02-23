using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    private int currency; //this is the Player's currency

    public Text currencyText; //this is for displaying the currency onscreen

    public int GetCurrency()
    {
        return currency; //gets the Player's current currency 
    }

    public void AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd; //add currency by the currencyToAdd
        currencyText.text = currency.ToString(); //display the currency onscreen 
    }


    public void SubtractCurrency(int currencyToSubtract)
    {
        currency -= currencyToSubtract; //subtract currency by the currencyToSubtract
        currencyText.text = currency.ToString(); //display the currency onscreen
    }
}