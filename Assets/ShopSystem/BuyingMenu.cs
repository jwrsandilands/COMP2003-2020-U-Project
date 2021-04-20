using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingMenu : MonoBehaviour
{
    public Image buyingPanel;

    private void OnBecameVisible()
    {
        buyingPanel.color = Color.blue;
    }

    public void ChangeColourToRed() 
    {
        buyingPanel.color = Color.red;
    }

    public void ChangeColourToGreen() 
    {
        buyingPanel.color = Color.green;
    }

    public void ChangeColourToBlue() 
    {
        buyingPanel.color = Color.blue;
    }





    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
