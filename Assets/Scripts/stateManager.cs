using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    private bool isCast = false;
    private bool canLure = true;
    private bool hasCaught = false;

    public bool IsCast { get => isCast; set => isCast = value; }
    public bool CanLure { get => canLure; set => canLure = value; }
    public bool HasCaught { get => hasCaught; set => hasCaught = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
