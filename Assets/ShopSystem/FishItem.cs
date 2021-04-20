using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishItem : MonoBehaviour
{
    private int fishValue;
    private int fishPrice = 25;
    private FishManager manager;

    [SerializeField]
    public Image fishImage;

    private void Start()
    {
        manager = FindObjectOfType<FishManager>();
    }

    public int GetValue()
    {
        return fishValue;
    }

    public int GetPrice()
    {
        return fishPrice;
    }

    public void SetValue(int inValue)
    {
        fishValue = inValue;
    }

    public Image GetImage()
    {
        return fishImage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            manager.AddValue();
            gameObject.SetActive(false);
        }
    }
}
