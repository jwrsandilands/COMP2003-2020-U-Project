using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimCrossHair : MonoBehaviour
{
    private Camera theCam;
    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenpoint.x, mouse.y - screenpoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    
}
