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
        //CharPhysics = GetComponent<Rigidbody2D>();
        //CharSprite = GetComponent<SpriteRenderer>();
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

        //switch (HoriPosition)
        //{
        //    case -1:
        //        transform.rotation = new Quaternion(0, 180, 0, 0);
        //        break;
        //    case 1:
        //        transform.rotation = new Quaternion(0, 0, 0, 0);
        //        break;
        //}
        // Commented this code out because it was breaking the cast mechanic,
        // will take another look at a later time.

        // changes sprite position based on axis input, speed and time control how far the sprite can move per second
        transform.position += new Vector3(HoriPosition, VertPosition, 0) * speed * Time.deltaTime;
    }

}
