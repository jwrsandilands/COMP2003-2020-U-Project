using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookLaunch : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    private bool startSlow = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("VelocitySlider").GetComponent<Slider>().value;
        rb.gravityScale = 1;
        rb.velocity = transform.right * speed;
        CameraFollow.instance.setTarget(this.gameObject);
        
    }

    private void Update()
    {
        if (transform.position.y < 0f)
        {
            startSlow = true;
        }
        if (startSlow == true)
        {
            rb.gravityScale = 0f;
            rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y) * 0.0075f, ForceMode2D.Impulse);
        }
        if (rb.velocity.x < 0.3f && rb.velocity.y < 0.3f && stateManager.instance.HasCaught == false && stateManager.instance.GotAway == false)
        {
            stateManager.instance.CanLure = true;
        }
    }


}
