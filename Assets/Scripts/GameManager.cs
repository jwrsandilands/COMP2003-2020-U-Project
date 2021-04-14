﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void EndGame() 
    {
        SceneManager.LoadScene("Menu");
    }

    
}
