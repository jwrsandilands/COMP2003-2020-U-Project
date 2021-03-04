using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    private bool isCast = false;
    private bool canLure = false;
    private bool hasCaught = false;
    private bool gotAway = false;

    private GameObject caughtFish;
    
    

    private bool rhythmStart = false;

    public static stateManager instance;

    public bool IsCast { get => isCast; set => isCast = value; }
    public bool CanLure { get => canLure; set => canLure = value; }
    public bool HasCaught { get => hasCaught; set => hasCaught = value; }
    public bool GotAway { get => gotAway; set => gotAway = value; }



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCaught == true && rhythmStart == false)
        {
            RhythmManager.instance.startAudio();
            rhythmStart = true;
        }
    }

    public void setCaughtFish(GameObject fish)
    {
        caughtFish = fish;
    }

    

    public void fishEscape()
    {
        hasCaught = false;
        gotAway = true;
        caughtFish.GetComponent<MoveTowardsHook>().enabled = false;
        caughtFish.GetComponent<FlockAgent>().enabled = true;
        RhythmManager.instance.endAudio();
    }

    public void Reset()
    {
     isCast = false;
     canLure = false;
     hasCaught = false;
     rhythmStart = false;
    }

    // code for when a fish is bought back successfully
    public void Success()
    {
        Destroy(caughtFish);
        Destroy(GameObject.FindGameObjectWithTag("Hook"));

        GameObject[] allFlock = GameObject.FindGameObjectsWithTag("flock");
        foreach (GameObject flock in allFlock)
            GameObject.Destroy(flock);

        Debug.Log("Fish Caught");
        Reset();
        RhythmManager.instance.endAudio();
        RhythmManager.instance.end();

        

        //insert code for what happens when a fish is caught
    }
}
