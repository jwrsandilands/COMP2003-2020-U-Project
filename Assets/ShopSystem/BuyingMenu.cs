using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingMenu : MonoBehaviour
{
    public Hook[] hooks;

    public RodItem[] rods;

    public BaitItem[] baits;

    public ReelItem[] reels;


    public Image[] images;

    public Text[] textPrices;

    public TransactionMenu transactionMenu;

    public GameObject buyingMenuPanel;

    public static bool isHook;
    public static bool isRod;
    public static bool isBait;
    public static bool isReel;


    private void OnEnable()
    {
        DisplayHookProducts();
    }

    public void DisplayRodProducts()
    {
        isRod = true;
        isHook = false;
        isBait = false;
        isReel = false;

        for(int i = 0; i < rods.Length; i++)
        {
            images[i].sprite = rods[i].getImage();
            textPrices[i].text = rods[i].getPrice().ToString();
        }
    }

    public void DisplayBaitProducts()
    {
        isRod = false;
        isHook = false;
        isBait = true;
        isReel = false;

        for (int i = 0; i < baits.Length; i++)
        {
            images[i].sprite = baits[i].getImage();
            textPrices[i].text = baits[i].getPrice().ToString();
        }
    }


    public void DisplayHookProducts()
    {
        isHook = true;
        isRod = false;
        isBait = false;
        isReel = false;

        for (int i = 0; i < hooks.Length; i++)
        {
            images[i].sprite = hooks[i].getImage();
            textPrices[i].text = hooks[i].getPrice().ToString();
        }
    }

    public void DisplayReelProducts()
    {
        isHook = false;
        isRod = false;
        isBait = false;
        isReel = true;

        for (int i = 0; i < reels.Length; i++)
        {
            images[i].sprite = reels[i].getImage();
            textPrices[i].text = reels[i].getPrice().ToString();
        }
    }


    public void OpenTransactionMenu(int index)
    {
        if (isHook)
        {
            buyingMenuPanel.SetActive(false);
            transactionMenu.menuPanel.SetActive(true);
            transactionMenu.DisplayHookData(hooks, index);
        }
        else if(isRod)
        {
            buyingMenuPanel.SetActive(false);
            transactionMenu.menuPanel.SetActive(true);
            transactionMenu.DisplayRodData(rods, index);
        }
        else if(isBait)
        {
            buyingMenuPanel.SetActive(false);
            transactionMenu.menuPanel.SetActive(true);
            transactionMenu.DisplayBaitData(baits, index);
        }
        else if(isReel)
        {
            buyingMenuPanel.SetActive(false);
            transactionMenu.menuPanel.SetActive(true);
            transactionMenu.DisplayReelData(reels, index);
        }
        
    }
}