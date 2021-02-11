using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HookIsNear : MonoBehaviour
{
    
    public Transform hooktran;
    public Transform Fish;
    public float radius = 10;

    //private CaughtOne catchDetector;
    

    IAstarAI ai;

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        //catchDetector = GameObject.FindGameObjectWithTag("Hook").GetComponent<CaughtOne>();
        
    }

    // Update is called once per frame
    void Update()
    {
         
        hooktran = GameObject.FindGameObjectWithTag("Hook").transform;
        
        

        if (Vector3.Distance(hooktran.position, Fish.position ) < radius)
        {
            GetComponent<WanderingDestinationSetter>().enabled = false;
            ai.destination = hooktran.position;
            ai.SearchPath();
            Debug.Log("hook is near");
        }
        else
        {
            GetComponent<WanderingDestinationSetter>().enabled = true;
            ai.SearchPath();
        }
    }

 
}
