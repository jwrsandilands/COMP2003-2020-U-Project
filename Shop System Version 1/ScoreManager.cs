using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score; //this is the amount of fish the Player currently has

    public Text scoreText; //this is for displaying the text onscreen


    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //sets fish Score equal to 0 
        scoreText.text = Score.ToString(); //displays the fish score onscreen
    }

    public int GetScore()
    {
        return Score; //return the Score
    }

    public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd; //adds Score by the pointsToAdd amount
        Debug.Log(Score); //shows this message
        scoreText.text = Score.ToString(); //displays the score onscreen
    }

    public void SubtractScore()
    {
        Score--; //decrement the score by 1
        Debug.Log(Score); //shows this message
        scoreText.text = Score.ToString(); //displays the score onscreen 
    }
}