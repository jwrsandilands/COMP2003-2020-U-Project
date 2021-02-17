using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotOne : MonoBehaviour
{
    public GameObject manager;
    public Vector2 lureTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "fish")
        {
            manager.GetComponent<stateManager>().HasCaught = true;
        }
    }

    private void Update()
    {
        if(manager.GetComponent<stateManager>().HasCaught == true && Input.GetMouseButton(0))
        {
            transform.position = Vector2.MoveTowards(transform.position, lureTo, 0.2f);
        }
    }
}
