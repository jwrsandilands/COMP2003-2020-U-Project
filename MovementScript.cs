using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    float speed;
    float TimetoTarget;
    float Fuel;
    public SpriteRenderer CharSprite;
    public Rigidbody2D CharPhysics;
    float HoriPosition;
    float VertPosition;


    void Start()
    {
        CharPhysics = GetComponent<Rigidbody2D>();
        CharSprite = GetComponent<SpriteRenderer>();
        Fuel = 5000;
        speed = 25;
    }

    void Update()
    {
        if (Fuel > 0)
        {
            BetterMovement();
        }
    }

    void BetterMovement()
    {
        Fuel += -1;
        // Reads inputs from keys wasd and registers either -1 or 1
        HoriPosition = Input.GetAxis("Horizontal");
        VertPosition = Input.GetAxis("Vertical");
        // flips the sprite depending on horizontal input
        switch (HoriPosition)
        {
            case -1:
                transform.rotation = new Quaternion(0, 180, 0, 0);
                break;
            case 1:
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
        }
        // changes sprite position based on axis input, speed and time control how far the sprite can move per second
        transform.position += new Vector3(HoriPosition, VertPosition, 0) * speed * Time.deltaTime;
    }

    //void Movement()
    //{
    //    switch ()
    //    {
    //        case Input.GetKey(KeyCode.W):
    //            Fuel += -10;
    //            transform.position += new Vector3(0, 0.05f, 0);
    //            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
    //            {
    //                transform.position += new Vector3(0, 0.1f, 0);
    //            }
    //            break;
    //    }

    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        Vector3 TargetPosition = Target.TransformPoint(new Vector3(0, 3, 0));
    //        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, TimetoTarget);
    //        Fuel += -10;
    //        transform.position += new Vector3(0, 0.05f, 0);
    //        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
    //        {
    //            transform.position += new Vector3(0, 0.1f, 0);
    //        }
    //    }
    //    if (Input.GetKeyUp(KeyCode.W))
    //    {
    //        transform.position += new Vector3(0, 0.1f, 0);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.position += new Vector3(-0.05f, 0, 0);
    //        CharSprite.flipX = true;
    //        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
    //        {
    //            transform.position += new Vector3(-0.1f, 0, 0);
    //        }
    //    }
    //    if (Input.GetKeyUp(KeyCode.A))
    //    {
    //        transform.position += new Vector3(-0.0f, 0, 0);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.position += new Vector3(0, -0.05f, 0);
    //        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
    //        {
    //            transform.position += new Vector3(0, -0.1f, 0);
    //        }
    //    }
    //    if (Input.GetKeyUp(KeyCode.S))
    //    {
    //        transform.position += new Vector3(0, -0.1f, 0);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.position += new Vector3(0.05f, 0, 0);
    //        CharSprite.flipX = false;
    //        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
    //        {
    //            transform.position += new Vector3(0.1f, 0, 0);
    //        }
    //    }
    //    if (Input.GetKeyUp(KeyCode.D))
    //    {
    //        transform.position += new Vector3(0.1f, 0, 0);
    //    }
    //}

}
