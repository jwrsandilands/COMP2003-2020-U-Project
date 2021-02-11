using UnityEngine;
using System.Collections;
using Pathfinding;
public class WanderingDestinationSetter : MonoBehaviour
{
    public float radius;
    IAstarAI ai;

    //for hook detection
    public Transform hooktran;
    public Transform Fish;
    public float hookDetectRadius = 10;

    void Start()
    {
        ai = GetComponent<IAstarAI>();
        
    }
    Vector2 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
        
        point += ai.position;
        
        if(point.x < 5 || point.y > -3 || point.x > 143 || point.y < -67 )
        {
            point = PickRandomPoint();
        }
        point.z = 0f;
        
        return point;
    }
    void Update()
    {
        
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedDestination || !ai.hasPath))
        {
            ai.destination = PickRandomPoint();
            
            ai.SearchPath();
        }
        //////////////////////////////////////////////////////////////

        //for hookdetection
        hooktran = GameObject.FindGameObjectWithTag("Hook").transform;
        if (Vector2.Distance(hooktran.position, Fish.position) < hookDetectRadius)
        {
            
            ai.destination = hooktran.position;
            ai.SearchPath();
            
        }
        
    }
}
