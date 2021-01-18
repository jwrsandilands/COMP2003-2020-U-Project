using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HookIsNear : MonoBehaviour
{
    public Transform hook;
    public Transform Fish;
    public float radius = 10;
    IAstarAI ai;

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<IAstarAI>();
       
    }

    // Update is called once per frame
    void Update()
    {
         hook = GameObject.FindGameObjectWithTag("Hook").transform;
        if (Vector3.Distance(hook.position, Fish.position) < radius)
        {
            GetComponent<WanderingDestinationSetter>().enabled = false;
            ai.destination = hook.position;
            ai.SearchPath();
            Debug.Log("hook is near");
        }
    }
}
