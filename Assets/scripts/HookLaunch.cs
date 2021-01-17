using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookLaunch : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    
    

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("VelocitySlider").GetComponent<Slider>().value;
        rb.gravityScale = 1;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
       
        
    }

    private void slow()
    {
        
       
    }


}
