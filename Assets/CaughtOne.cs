using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtOne : MonoBehaviour
{
    private bool caught = false;
    // Start is called before the first frame update


     void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("test");
            
            
        
    }

    public bool getCaught()
    {
        return caught;
    }

    public void setCaught(bool isCaught)
    {
        caught = isCaught;
    }

}
