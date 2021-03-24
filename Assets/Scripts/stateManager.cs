using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    [SerializeField]
    private bool isCast = false;
    [SerializeField]
    private bool canLure = false;
    [SerializeField]
    private bool hasCaught = false;
    [SerializeField]
    private bool gotAway = false;

    private GameObject caughtFish;

    public Camera theCam;
    
    

    private bool rhythmStart = false;

    public static stateManager instance = null;

    public bool IsCast { get => isCast; set => isCast = value; }
    public bool CanLure { get => canLure; set => canLure = value; }
    public bool HasCaught { get => hasCaught; set => hasCaught = value; }
    public bool GotAway { get => gotAway; set => gotAway = value; }



    // Start is called before the first frame update

    void Awake()
    {
        if(instance != null)
        {
            Destroy(GetComponent<stateManager>());
            return;
        }
        instance = this;
        
    }
    //void Start()
    //{
    //    stateManagerInstance = this;
    //}

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
        

        ResetScene();
      
    }

    

    // code for when a fish is bought back successfully
    public void Success()
    {
        Destroy(caughtFish);

        ResetScene();
        Debug.Log("Fish Caught");
        
        RhythmManager.instance.endAudio();
        RhythmManager.instance.end();

        

        //insert code for what happens when a fish is caught
    }

    private void ResetScene()
    {
        theCam.GetComponent<MoveToOrigin>().enabled = true;
        Destroy(GameObject.FindGameObjectWithTag("hookParent"));

        GameObject[] allFlock = GameObject.FindGameObjectsWithTag("flock");
        foreach (GameObject flock in allFlock)
            GameObject.Destroy(flock);
        
        isCast = false;
     canLure = false;
     hasCaught = false;
     rhythmStart = false;
        gotAway = false;
       
    }
}
