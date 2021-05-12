using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionMenu : MonoBehaviour
{

    public Text itemNameText; //this is for item name text

    public Image productImage; //this is for the product image 

    public Image[] stars; //holds the five star rating system

    public Sprite goldStar; //this is the gold star which represents the level
    public Sprite blackStar; //this is the black star which fills in the images that are greater than the level

    public Text buyItemPrompt; //this is for the buy item prompt

    public GameObject menuPanel; //this is for setting the panel active and unactive

    public BuyingMenu buyingMenu; //a reference for the buying menu 

    public Currency currencyManager; //a reference for the currency manager

    private int productIndex; //this is for current element of the array
    
    //these arrays are used for the buy function 
    private Hook[] hookArray; 
    private RodItem[] rodArray;
    private BaitItem[] baitArray;
    private ReelItem[] reelArray;

    //used for enabling and disabling the acceptButton
    public Button acceptButton;


  
    public void DisplayHookData(Hook[] hooks, int index)
    {
        //gets the image and name of the product
        itemNameText.text = hooks[index].getName();
        productImage.sprite = hooks[index].getImage();

        //displays the number of stars based on the player's level (if level is at 2, it will display two stars)

        for(int i = 0; i < hooks[index].getLevel(); i++)
        {
            if (i < hooks[index].getLevel())
            {
                stars[i].sprite = goldStar;
            }
        }

        //the hook's level goes into this level variable

        int level = hooks[index].getLevel();

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for(int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + hooks[index].getPrice() + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        hookArray = hooks;
    }

    public void DisplayRodData(RodItem[] rods, int index)
    {
        //gets the image and name of the product
        itemNameText.text = rods[index].getName();
        productImage.sprite = rods[index].getImage();

        //displays the number of stars based on the product's level (if level is at 2, it will display two stars)
        for (int i = 0; i < rods[index].getLevel(); i++)
        {
            if (i < rods[index].getLevel())
            {
                stars[i].sprite = goldStar;
            }
        }

        //the rod's level goes into this level variable
        int level = rods[index].getLevel();

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + rods[index].getPrice() + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        rodArray = rods;
    }

    public void DisplayBaitData(BaitItem[] baits, int index)
    {
        //gets the image and name of the product
        itemNameText.text = baits[index].getName();
        productImage.sprite = baits[index].getImage();

        //displays the number of stars based on the product's level (if level is at 2, it will display two stars)
        for (int i = 0; i < baits[index].getLevel(); i++)
        {
            if (i < baits[index].getLevel())
            {
                stars[i].sprite = goldStar;
            }
        }

        //the bait's level goes into this level variable
        int level = baits[index].getLevel();

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)
        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + baits[index].getPrice() + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        baitArray = baits;
    }

    public void DisplayReelData(ReelItem[] reels, int index)
    {
        //gets the image and name of the product
        itemNameText.text = reels[index].getName();
        productImage.sprite = reels[index].getImage();

        //displays the number of stars based on the player's level (if level is at 2, it will display two stars)

        for (int i = 0; i < reels[index].getLevel(); i++)
        {
            if (i < reels[index].getLevel())
            {
                stars[i].sprite = goldStar;
            }
        }

        //the hook's level goes into this level variable

        int level = reels[index].getLevel();

        //the rest of the stars are given the blackstar sprite (if level is at 2, the last three will be the blackstar sprite)

        for (int i = level; i < stars.Length; i++)
        {
            stars[i].sprite = blackStar;
        }

        //displays this text
        buyItemPrompt.text = "This item costs: " + reels[index].getPrice() + " coins. " + " Do you want to buy it?";

        //stores these parameters into these variables 
        productIndex = index;
        reelArray = reels;
    }


    public void Decline()
    {
        menuPanel.SetActive(false); //disables this menu
        buyingMenu.buyingMenuPanel.SetActive(true); //enables the buying menu
        acceptButton.enabled = true; //enables the accept button
    }

    public void Buy()
    {
        if (BuyingMenu.isHook) //if the product is a hook
        {
            //Debug.Log(productIndex);
            //Debug.Log(currencyManager.currency);
            //int cost = hookArray[productIndex].getPrice();
            //Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= hookArray[productIndex].getPrice())
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(hookArray[productIndex].getPrice()); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// HOOK
            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }

        if (BuyingMenu.isRod) //if the product is a rod
        {
            //int cost = rodArray[productIndex].getPrice();
            // Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= rodArray[productIndex].getPrice())
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(rodArray[productIndex].getPrice()); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// ROD
            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }
        else if (BuyingMenu.isBait) //if the product is a bait
        {
            //int cost = baitArray[productIndex].getPrice();
            //Debug.Log(cost);

            //if the currency is greatyr than the product price
            if (currencyManager.GetCurrency() >= baitArray[productIndex].getPrice())
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(baitArray[productIndex].getPrice()); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// BAIT
            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }
        else if (BuyingMenu.isReel)
        {
            if (currencyManager.GetCurrency() >= reelArray[productIndex].getPrice())
            {
                buyItemPrompt.text = "Thank you for your purchase.";
                currencyManager.SubtractCurrency(reelArray[productIndex].getPrice()); //subtract the currency by the product's price
                acceptButton.enabled = false; //disable the accept button

                //INSERT INVENTORY CODE HERE//// BAIT
            }
            else
            {
                buyItemPrompt.text = "You do not have enough money to purchase this product";
            }
        }



        
    }


}
