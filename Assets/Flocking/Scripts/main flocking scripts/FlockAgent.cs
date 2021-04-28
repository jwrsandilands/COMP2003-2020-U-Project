using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{

    private bool isCaught = false;

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    public int fishLevel;

    

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void initialise(Flock flock)
    {
        
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        if (!isCaught)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
    }


    //method: move towards hook
    public void MoveTowards()
    {
        gameObject.tag = "caughtfish";
        isCaught = true;
        
        this.GetComponent<MoveTowardsHook>().enabled = true;

    }
}
