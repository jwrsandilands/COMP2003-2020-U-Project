using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotOne : MonoBehaviour
{
    
    public Vector2 lureTo = GameObject.FindGameObjectWithTag("castPoint").transform.position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fish" && stateManager.instance.CanLure == true)
        {
            stateManager.instance.setCaughtFish(collision.gameObject);

            //add code later for catching multiple fish
            stateManager.instance.CanLure = false;

            stateManager.instance.HasCaught = true;
        }
    }

    private void Update()
    {
        if(stateManager.instance.HasCaught == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, lureTo, 0.05f);
        }
        if(Vector2.Distance(this.transform.position, lureTo) < 3f)
        {
            stateManager.instance.Success();
        }
    }
}
