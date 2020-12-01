using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //this is a reference to the Character Controller
    public float moveSpeed = 12f; //this is for controlling the speed of the movement 
    public float gravity = -9.81f; //this is the gravity of the Player 
    public float jumpHeight = 5f; //this is how high the Player will jump

    public Transform groundCheck; //this is for checking if the Player is on the Ground
    public float groundDistance = 0.4f; //this is the radius of the sphere that will be used to check if the Player is grounded
    public LayerMask groundMask; //controls what objects the sphere should check for

    Vector3 velocity; //this will store the current velocity of the Player 
    bool isGrounded; //stores whether the Player is grounded or not 

    // Update is called once per frame
    void Update()
    {
        //runs the function physics.checksphere function with these inputs as arguments and stores it in isGrounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //creates a sphere based on the groundCheck's position, the radius of the groundCheck, and what objects the sphere should check for

        if (isGrounded && velocity.y < 0) //if the Player is grounded and the velocity on the y is less than 0 
        {
            velocity.y = -2f; //set the velocity on the y to -2f (-2f forces the Player to the ground - the isGrounded code block might register before the Player is completely on the ground)
        }

        float movementX = Input.GetAxis("Horizontal"); //gets the value of the horizontal input and stores it in a float variable called movementX
        float movementZ = Input.GetAxis("Vertical"); //gets the value of the vertical input and stores it in a float variable called movementZ

        //creates a direction that the player moves in based on the movement in the X and Z
        //the calculation below is stored in a Vector3 variable called move 
        Vector3 move = transform.right * movementX + transform.forward * movementZ;

        //this allow the characterController to move in the world space with the set speed as well as frame-independent 
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) //if the Player press the jump button (space) and the Player is grounded
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //takes the sqrt root of the jumpHeight multiplied by -2f multiplied by gravity and stores it in velocity.y
        }

        //increases the velocity on the up and down axis by a certain gravity amount (as well as being frame-independent)
        velocity.y += gravity * Time.deltaTime;

        //adds the velocity to the Player (the Player's frame-independent movement is based on the velocity) 
        controller.Move(velocity * Time.deltaTime);
    }
}