using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cast : MonoBehaviour
{

    public Animator castAnimation;

    private bool casting;
    private float atHookTime = 0.9f;
    private float atHook;


    public Transform castPoint;
    public Transform CrossHair;
    public GameObject hookprefab;
    private float angle;
    private Quaternion q;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && stateManager.instance.IsCast == false)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                stateManager.instance.IsCast = true;
                casting = true;
                CastHookAnim();
            }
            // Check if the mouse was clicked over a UI element
        }

        if (casting && Time.time > atHook)
        {
            CastHook();
        }
    }

    void CastHookAnim()
    {
        castAnimation.Play("Cast");
        atHook = Time.time + atHookTime;
        casting = true;
        
        
    }

    void CastHook()
    {
        casting = false;
        Vector3 dir = CrossHair.position - castPoint.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(0f, 0f, angle);

        Instantiate(hookprefab, castPoint.position, q);
    }
}
