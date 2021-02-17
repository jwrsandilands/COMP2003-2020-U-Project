﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Transform spawnPoint;
    GameObject hook;
    public GameObject manager;
    private bool chance = false;

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public int fishLevel;
    public int range = 10;
    public FlockBehaviour behaviour;

    [Range(1, 15)]
    public int startingCount = 250;
    const float AgentDensity = 1f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        manager.GetComponent<stateManager>().CanLure = true;
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                (Vector2)spawnPoint.position + Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "SunFish_Agent" + i;
            newAgent.initialise(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hook = GameObject.FindGameObjectWithTag("Hook");
        foreach (FlockAgent agent in agents)
        {
            
            if(hook != null && manager.GetComponent<stateManager>().CanLure == true && Vector2.Distance(hook.transform.position, agent.transform.position) < range)
            {
                
                chance = attractChance();
                
                if(chance == true)
                {
                    Debug.Log("true if");
                    manager.GetComponent<stateManager>().CanLure = false;
                    agent.MoveTowards();
                    
                }
                if(chance == false) 
                {
                    Debug.Log("false if");
                    manager.GetComponent<stateManager>().CanLure = false;
                    
                    Invoke("SetBoolBack", 0.5f);

                    List<Transform> context = getNearbyObjects(agent);
                    Vector2 move = behaviour.calculateMove(agent, context, this);
                    move *= driveFactor;
                    if (move.sqrMagnitude > squareMaxSpeed)
                    {
                        move = move.normalized * maxSpeed;
                    }
                    agent.Move(move);

                    
                }
            }

            else 
            {
                List<Transform> context = getNearbyObjects(agent);
                Vector2 move = behaviour.calculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
            agent.Move(move); 
            }
            
            
            
        }
    }

    List<Transform> getNearbyObjects(FlockAgent agent)
    {
        
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);

            }
        }
        return context;
    }

    private bool attractChance()
    {
        int randomNum = Random.Range(0, 9);
        bool[] isLured = new bool[10] { true, false, false, false, false, false, false, false, false, false };
        return isLured[randomNum];

        
    }

    private void SetBoolBack()
    {
        Debug.Log("Invoked");
        manager.GetComponent<stateManager>().CanLure = true;
        Debug.Log(GetComponent<stateManager>().CanLure);
    }
   
}