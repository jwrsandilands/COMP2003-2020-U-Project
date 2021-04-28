using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public int power = 1;
    public int catchDifficulty = 1;

    public static PlayerStats instance;

    private void Start()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        power = 1 * playerInventory.itemSelected.GetComponent<Rod>().power;
        catchDifficulty = playerInventory.itemSelected.GetComponent<Rod>().catchDifficulty;
    }



}
