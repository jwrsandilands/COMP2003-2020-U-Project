using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //get fish to Spawn
    public GameObject[] allFlocks;

    private int fishLvl;

    private Vector2 pos;

    //Set up colider variables
    public Collider2D colliderLvl1;
    public Collider2D colliderLvl2;
    public Collider2D colliderLvl3;
    public Collider2D colliderLvl4;
    public Collider2D colliderLvl5;


    //Get Number of Fish to Spawn
    private int maxFish;
    

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
        for (int i = 0; i < allFlocks.Length; i++)
        {
            fishLvl = allFlocks[i].GetComponent<Flock>().agentPrefab.fishLevel;
            maxFish = allFlocks[i].GetComponent<Flock>().amountOfFlock;
            int count = 1;
            while (count <= maxFish)
            {
                if(fishLvl == 1)
                {
                    pos = new Vector3(Random.Range(colliderLvl1.bounds.min.x, colliderLvl1.bounds.max.x), Random.Range(colliderLvl1.bounds.min.y, colliderLvl1.bounds.max.y));
                }
                if (fishLvl == 2)
                {
                    pos = new Vector3(Random.Range(colliderLvl2.bounds.min.x, colliderLvl2.bounds.max.x), Random.Range(colliderLvl2.bounds.min.y, colliderLvl2.bounds.max.y));
                }
                if (fishLvl == 3)
                {
                    pos = new Vector3(Random.Range(colliderLvl3.bounds.min.x, colliderLvl3.bounds.max.x), Random.Range(colliderLvl3.bounds.min.y, colliderLvl3.bounds.max.y));
                }
                if (fishLvl == 4)
                {
                    pos = new Vector3(Random.Range(colliderLvl4.bounds.min.x, colliderLvl4.bounds.max.x), Random.Range(colliderLvl4.bounds.min.y, colliderLvl4.bounds.max.y));
                }
                if (fishLvl == 5)
                {
                    pos = new Vector3(Random.Range(colliderLvl5.bounds.min.x, colliderLvl5.bounds.max.x), Random.Range(colliderLvl5.bounds.min.y, colliderLvl5.bounds.max.y));
                }

                Quaternion rotate = new Quaternion(0, 0, 0, 0);

                Instantiate(allFlocks[i], pos, rotate);
                count++;
            }
        }
    }
}
