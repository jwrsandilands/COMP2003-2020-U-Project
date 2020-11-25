using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D theRb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Cast();
    }

    void Cast()
    {
        theRb.velocity = transform.right * speed;
        theRb.gravityScale = 1;

    }
}
