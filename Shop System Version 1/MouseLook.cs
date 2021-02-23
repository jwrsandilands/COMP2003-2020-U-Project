using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; //this is for the speed of the mouse look
    public Transform playerBody; //this is for the Player to look up and down
    float xRotation = 0f; //this is for rotating the camera on the X-Axis

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the Cursor in the game screen 
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    { 
        //these two declarations allows the Player to move the mouse horiztonally and vertically plus frame-independent movement 
        //the mouse sensitivity indicates how the fast the mouse will move if the Player moves it
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //decreases the xrotation with every frame (rotation is subtracted to prevent the rotation from being flipped)
        //this is used for moving the mouse vertically 
        xRotation -= mouseY;

        //runs the Mathf.Clamp with xRotation, -90f, and 90f as arguments
        //stores the result in xRotation (this clamps the rotation between -90 and 90 to avoid over-rotating the camera 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
 
        //runs the Quaternion.Euler function with xRotation, 0f and 0f as arguments
        //The Quaternion class is responsible for rotations and Euler is for rotating at a specific angle
        //stores the result of the function in transform.localRotation (localRotation refers to the rotation value of the Gameobject which is the Main Camera)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //applies the rotation on the X-Axis 

        //allows the Player to look from left to right 
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
