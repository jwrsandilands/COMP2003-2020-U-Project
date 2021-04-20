using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject scoreUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            shopUI.SetActive(true); 
            scoreUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
    }
}
