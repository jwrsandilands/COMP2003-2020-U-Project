using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public string hookname;
    public int hookPrice;
    public string hookInfo;
    public int hookLevel;

    //private void Start()
    //{
     //   Debug.Log(getName() + getPrice() + getInfo() + getLevel());
    //}
    public string getName()
    {
        return hookname;

    }

    public int getPrice()
    {
        return hookPrice;
    }

    public string getInfo()
    {
        return hookInfo;
    }

    public int getLevel()
    {
        return hookLevel;
    }
}
