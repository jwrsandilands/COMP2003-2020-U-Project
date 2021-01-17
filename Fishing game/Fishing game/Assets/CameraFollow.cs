using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Transform camTrans;

    public float smoothFloat = 0.125f;
    public Vector3 offset;
    

    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.GetComponent<Transform>();
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Hook").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
