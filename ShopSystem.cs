using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    private bool hasEnteredShop; //checks whether the Player has entered the shop
    public GameObject shopPanel; //this is for displaying the shop menu
    public Holder holder; //object instance of the holder class
    public ScoreManager scoreManager; //object instance of the ScoreManager class
    public CurrencyManager currencyManager; //object instance of the CurrencyManager class

    public EnableRod rodExec; //object instance of the EnableRod class
    public GameObject fishingRod; //this is for the fishingRod gameobject that the shop is selling

    private int storePrice = 300; //this is the store price for the fishing role (currently at 300)
    public Text storePriceText; //displays the store price text
    public Text shopNotification; //displays the shop notification when something occurs such as buying or selling
    public Text fishingRodText; //this is for displaying the fishingRodText after buying it 
    public GameObject item; //this is for the fishing rod (used as an argument for the function ShowFishingRod())

    private bool hasBoughtItem; //checks whether the Player has bought the item or not 

    // Start is called before the first frame update
    void Start()
    {
        storePriceText.text = storePrice.ToString(); //display the price text 
    }

   
    public void BuyItem()
    {
        if(storePrice == currencyManager.GetCurrency()) //if the storePrice is equal to the currency value
        {
            currencyManager.SubtractCurrency(storePrice); //run this function with storePrice as an argument
            holder.AddToInventory(item); //run this function with item as an argument
            shopNotification.text = "Thank you for your purchase!"; //display this message onscreen
            hasBoughtItem = true; //set hasBoughtItem to true

        }
        else
        {
            shopNotification.text = "You don't have enough coins"; //display this message onscreen
        }
    }

    public void SellItem()
    {
        if(scoreManager.GetScore() != 0) //if the score value does not equal 0
        {
            scoreManager.SubtractScore(); //run this function
            currencyManager.AddCurrency(100); //run this function with 100 as an argument 
            shopNotification.text = "Thank you for selling! Your currency is at " + currencyManager.GetCurrency().ToString(); //display this message with the current currency value
        }
        else
        {
            shopNotification.text = "You have no more fish to sell"; //display this message onscreen
        }
        
    }

    public void LeaveStore()
    {
        shopPanel.SetActive(false); //disable visibility of the shop menu
        shopNotification.text = ""; //display no text

        if(hasBoughtItem) //if hasBoughItem equals true
        {
            fishingRodText.gameObject.SetActive(true); //enable visibility of the text
            rodExec.ShowFishingRod(fishingRod); //run this function with fishingRod as an argument
            hasBoughtItem = false; //set hasBoughtItem to false
            Cursor.lockState = CursorLockMode.Locked; //sets the cursor to be inside the game screen
            Cursor.visible = false; //disables the cursor graphic
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") && !hasEnteredShop) //if the Player has entered the trigger area and hasEnteredShop is false
        {
            hasEnteredShop = true; //set hasEnteredShop to true
            Debug.Log("Welcome to the Shop"); //display this message in the console
            Debug.Log(hasEnteredShop); //displays this message in the console
            shopPanel.SetActive(true); //enables visibility of the shop menu
            Cursor.lockState = CursorLockMode.None; //the cursor has no lock state
            Cursor.visible = true; //enables the cursor graphic
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character") && hasEnteredShop)  //if the Player has exited the trigger area and hasEnteredShop is true
        {
            hasEnteredShop = false; //set hasEnteredShop to false
            Debug.Log("Thanks for stopping by"); //display this message in the console
            Debug.Log(hasEnteredShop); //display this message in the console
        }
    }
}