using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //get fish to Spawn
    public GameObject[] flocks;

    //Set up colider variables
    public Collider2D collider2;
    Vector3 cMin, cMax;

    //Get Number of Fish to Spawn
    private int maxFish;
    //set co-ordinates Fish Spawn in
    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        //////could not get this code to work so hard to harcode variables
        //collider2 = GetComponent<Collider2D>();
        //cMin = collider2.bounds.min;
        //cMax = collider2.bounds.max;

        //xMin = cMin.x;
        //xMax = cMax.x;
        //yMin = cMin.y;
        //yMax = cMax.y;

        //OutputData();
        /////////

        spawn();
        

    }

    void OutputData()
    {
        Debug.Log("Fish Collider bound Minimum : " + cMin);
        Debug.Log("Fish Collider bound Maximum : " + cMax);
        Debug.Log("Fish Co-Ordinate bound Minimum : (" + xMin + ", " + yMin + ")");
        Debug.Log("Fish Co-Ordinate bound Maximum : (" + xMax + ", " + yMax + ")");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("flock") == null)
      {
           spawn();
       }
    }

    public void spawn()
    {
        for (int i = 0; i < flocks.Length; i++)
        {

            maxFish = flocks[i].GetComponent<Flock>().amountOfFlock;
            int count = 1;
            while (count <= maxFish)
            {
                Vector2 pos = new Vector3(Random.Range(0.5f, 144.388f), Random.Range(-65.2f, -1.199999f));
                Quaternion rotate = new Quaternion(0, 0, 0, 0);

                Instantiate(flocks[i], pos, rotate);
                count++;
            }
        }
    }
}
