using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreate : MonoBehaviour
{
    //Get Planet Object to spawn
    public GameObject Planet;

    //Set up colider variables
    public Collider2D collider;
    Vector3 cMin, cMax;

    //Get Number of Planets to Spawn
    public int maxPlanets;
    //set co-ordinates Planets Spawn in
    float xMin, xMax, yMin, yMax;

    

    // Start is called before the first frame update
    void Start()
    {

        

        collider = GetComponent<Collider2D>();
        cMin = collider.bounds.min;
        cMax = collider.bounds.max;

        xMin = cMin.x;
        xMax = cMax.x;
        yMin = cMin.y;
        yMax = cMax.y;

        //added by James to disable collision with hook
        collider.enabled = !collider.enabled;
        /////

        OutputData();

        int count = 1;
        while(count <= maxPlanets)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            Quaternion rotate = new Quaternion(0, 0, 0, 0);
            
            Instantiate(Planet, pos, rotate);
            count++;
        }

        
        //added by James to get pathfinder to scan the generated map for Fish AI
        AstarPath.active.Scan();

    }

    void OutputData()
    {
        Debug.Log("Collider bound Minimum : " + cMin);
        Debug.Log("Collider bound Maximum : " + cMax);
        Debug.Log("Co-Ordinate bound Minimum : (" + xMin + ", " + yMin + ")");
        Debug.Log("Co-Ordinate bound Maximum : (" + xMax + ", " + yMax + ")");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
