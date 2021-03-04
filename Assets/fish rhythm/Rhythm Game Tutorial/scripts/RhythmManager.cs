using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    public GameObject HB;

    public GameObject[] beatSpawn = new GameObject[4];

    public GameObject[] arrows = new GameObject[4];

    public GameObject noteHolder;

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller bs;

    public static RhythmManager instance;

    public int currentScore = 300;
    public int scorePerNote = 10;
    public int scorePerGoodNote = 15;
    public int scorePerPerfectNote = 25;
    public int scorePerMissedNote = -20;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshholds;


    //public Text scoreText;
   // public Text multiText;

    void Start()
    {
        instance = this;
       // scoreText.text = "score: " + currentScore;
        currentMultiplier = 1;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (currentScore == 0 && stateManager.instance.HasCaught == true)
        {
            currentScore = 0;
            HB.GetComponent<Slider>().value = currentScore;

            
            end();
            stateManager.instance.fishEscape();
            


        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
        HB.GetComponent<Slider>().value = currentScore;

        if (currentMultiplier - 1 < multiplierThreshholds.Length)
        {
            multiplierTracker++;

            if (multiplierThreshholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
       // multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
       // scoreText.text = "score: " + currentScore;
        
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        if(currentScore > 300)
        {
            currentScore = 300;
        }
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        if (currentScore > 300)
        {
            currentScore = 300;
        }
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        if (currentScore > 300)
        {
            currentScore = 300;
        }
        NoteHit();
    }


    public void NoteMissed()
    {
        Debug.Log("missed note");

        currentScore += scorePerMissedNote;
        
       // scoreText.text = "score: " + currentScore;

        currentMultiplier = 1;
        multiplierTracker = 0;

       // multiText.text = "Multiplier: x" + currentMultiplier;
    }

    void Deplete()
    {
        
        if(currentScore > 0)
        {
            currentScore -= 25;
            if(currentScore < 0)
            {
                currentScore = 0;
            }
            HB.GetComponent<Slider>().value = currentScore;
           // scoreText.text = "score: " + currentScore;
        }
    }

    void rhythmGenerator()
    {
        int[] rhythm = new int[1000];
        System.Random randNum = new System.Random();
        for(int i = 0; i< rhythm.Length; i++)
        {
            rhythm[i] = randNum.Next(1, 10);
        }
        int count = 0;
        
        foreach (int beat in rhythm)
        {
            if(beat == 1)
            {
                Instantiate(arrows[0], beatSpawn[0].transform.position + (beatSpawn[0].transform.up * count), arrows[0].transform.rotation, noteHolder.transform);
            }
            if (beat == 2)
            {
                Instantiate(arrows[1], beatSpawn[1].transform.position + (beatSpawn[1].transform.up * count), arrows[1].transform.rotation, noteHolder.transform);
            }
            if (beat == 3)
            {
                Instantiate(arrows[2], beatSpawn[2].transform.position + (beatSpawn[2].transform.up * count), arrows[2].transform.rotation, noteHolder.transform);
            }
            if (beat == 4)
            {
                Instantiate(arrows[3], beatSpawn[3].transform.position + (beatSpawn[3].transform.up * count), arrows[3].transform.rotation, noteHolder.transform);
            }
            if (beat == 5)
            {
                Instantiate(arrows[0], beatSpawn[0].transform.position + (beatSpawn[0].transform.up * count), arrows[0].transform.rotation, noteHolder.transform);
                Instantiate(arrows[3], beatSpawn[3].transform.position + (beatSpawn[3].transform.up * count), arrows[3].transform.rotation, noteHolder.transform);
            }
            if (beat == 6)
            {
                Instantiate(arrows[1], beatSpawn[1].transform.position + (beatSpawn[1].transform.up * count), arrows[1].transform.rotation, noteHolder.transform);
                Instantiate(arrows[2], beatSpawn[2].transform.position + (beatSpawn[2].transform.up * count), arrows[2].transform.rotation, noteHolder.transform);
            }
            if (beat == 7)
            {
                Instantiate(arrows[0], beatSpawn[0].transform.position + (beatSpawn[0].transform.up * count), arrows[0].transform.rotation, noteHolder.transform);
                Instantiate(arrows[1], beatSpawn[1].transform.position + (beatSpawn[1].transform.up * count), arrows[1].transform.rotation, noteHolder.transform);
            }
            if (beat == 8)
            {
                Instantiate(arrows[2], beatSpawn[2].transform.position + (beatSpawn[2].transform.up * count), arrows[2].transform.rotation, noteHolder.transform);
                Instantiate(arrows[3], beatSpawn[3].transform.position + (beatSpawn[3].transform.up * count), arrows[3].transform.rotation, noteHolder.transform);
            }
            if (beat == 9)
            {
                Instantiate(arrows[1], beatSpawn[1].transform.position + (beatSpawn[1].transform.up * count), arrows[1].transform.rotation, noteHolder.transform);
                Instantiate(arrows[3], beatSpawn[3].transform.position + (beatSpawn[3].transform.up * count), arrows[3].transform.rotation, noteHolder.transform);
            }
            if (beat == 10)
            {
                Instantiate(arrows[0], beatSpawn[0].transform.position + (beatSpawn[0].transform.up * count), arrows[0].transform.rotation, noteHolder.transform);
                Instantiate(arrows[3], beatSpawn[3].transform.position + (beatSpawn[3].transform.up * count), arrows[3].transform.rotation, noteHolder.transform);
            }
            count++;
        }
    }

    public void startAudio()
    {
        rhythmGenerator();

        InvokeRepeating("Deplete", 5f, 1.0f);
        startPlaying = true;
        bs.hasStarted = true;

        theMusic.Play();

        HB.GetComponent<Slider>().maxValue = currentScore;
        HB.GetComponent<Slider>().value = currentScore;
    }

    public void endAudio()
    {
        bs.hasStarted = false;
        startPlaying = false;
        theMusic.Stop();
    }

    public void end()
    {
        CancelInvoke("Deplete");
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
        foreach (GameObject arrow in arrows)
            GameObject.Destroy(arrow);
    }
}
