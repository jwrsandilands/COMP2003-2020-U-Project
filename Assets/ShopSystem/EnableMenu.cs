using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public GameObject buyingMenuPanel;
    public GameObject sellingMenuPanel;

    public void EnableBuyingMenu() 
    {
        sellingMenuPanel.SetActive(false); 
        buyingMenuPanel.SetActive(true);
    }

    public void EnableSellingMenu() 
    {
        buyingMenuPanel.SetActive(false);
        sellingMenuPanel.SetActive(true);
    }
}
