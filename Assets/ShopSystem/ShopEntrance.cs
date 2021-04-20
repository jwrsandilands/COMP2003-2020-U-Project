using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject shopEntranceButton;
    public GameObject addFishButton;

    public void EnterStore()
    {
        shopUI.SetActive(true);
        shopEntranceButton.SetActive(false);
        addFishButton.SetActive(false);
    }
}
