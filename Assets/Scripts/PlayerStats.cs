using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public int power = 1;
    public int attraction = 1;
    public int catchDifficulty = 1;
    public int speed = 1;

    public static PlayerStats instance;

    private void Start()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        power = 1 * playerInventory.rodSelected.GetComponent<Rod>().power;
        attraction = 1 * playerInventory.baitSelected.GetComponent<Bait>().attraction;
        catchDifficulty = 1 * playerInventory.hookSelected.GetComponent<HookItem>().catchDifficulty;
        speed = 1 * playerInventory.reelSelected.GetComponent<Reel>().speed;
    }



}
