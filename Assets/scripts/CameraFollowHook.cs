using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHook : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    void Update()
    {
        try
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        }
        catch { }
    }
    // Isn't efficient use of the update function however 
    // the fixedUpdate function bugged out player movement.


    void SwitchTarget(Transform newTransform) 
    {
        target = newTransform;
    }
    // Can be used for switching the camera to the hook.
}
