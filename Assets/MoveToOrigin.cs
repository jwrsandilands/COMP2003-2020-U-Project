using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOrigin : MonoBehaviour
{
    public Transform endMarker;
    private Transform startMarker;
    public AnimationCurve theCurve;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CameraFollow>().enabled = false;
        startMarker = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Time.deltaTime);

        if(transform.position == endMarker.position)
        {
            this.enabled = false;
            GetComponent<CameraFollow>().enabled = true;
        }
    }
}
