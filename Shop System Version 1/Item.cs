using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject fish; //this is for the gameobject itself

    public float rotateSpeed; //how much speed should the gameobject rotate by

    public int fishValue; //the value of the gameobject 

    public ScoreManager scoreManager; //object instance for using the methods and fields

    public Holder holder; //object instance for using the methods and fields

   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); //rotates the gameobject on the Y with the rotatespeed (frame-independent)
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.AddScore(fishValue); //runs this function with fishValue as a parameter
        holder.AddToArray(fish); //runs this function with fish as a parameter
        gameObject.SetActive(false); //disables visibility of the object 
    }
}