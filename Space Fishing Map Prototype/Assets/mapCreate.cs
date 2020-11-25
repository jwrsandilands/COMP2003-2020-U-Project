using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreate : MonoBehaviour
{
    public GameObject Planet;

    public float xMin, xMax, yMin, yMax;
    public int maxPlanets;

    // Start is called before the first frame update
    void Start()
    {
        int count = 1;
        while(count <= maxPlanets)
        {
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            Quaternion rotate = new Quaternion(0, 0, 0, 0);
            
            Instantiate(Planet, pos, rotate);
            count++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
