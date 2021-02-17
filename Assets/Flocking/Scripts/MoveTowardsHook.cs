using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsHook : MonoBehaviour
{
    public GameObject manager;

    

    private Transform endPoint;

    
    private Vector2 finalPos;
    private float graphValue;
    private float startTime = 0;

    void Start()
    {
        this.GetComponent<FlockAgent>().enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        finalPos = GameObject.FindGameObjectWithTag("Hook").transform.position;
        if ((Vector2)transform.position != finalPos)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, finalPos, 0.5f);
            
        }

        
        
    }

    
    
}
