using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int currency;
    public Text currencyText;

    //public Text sellingMenuCurrency;

    //private void Start()
    //{
       // SetCurrency(20);
   // }

    public int GetCurrency()
    {
        return currency;
    }

    public void SetCurrency(int inCurrency)
    {
        currency = currency + inCurrency;
        currencyText.text = currency.ToString();
    }


    //public void ShowCurrency()
    //{
    //    sellingMenuCurrency.text = currency.ToString();
    //}
}
