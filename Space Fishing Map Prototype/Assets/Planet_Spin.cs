﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Spin : MonoBehaviour
{
    public float minSpin, maxSpin;
    public float spinNumber;
    public float minSize, MaxSize;
    public float sizeNumber;

    // Start is called before the first frame update
    void Start()
    {
        spinNumber = Random.Range(minSpin, maxSpin);
        sizeNumber = Random.Range(minSize, MaxSize);
        Vector3 scale = new Vector3(sizeNumber, sizeNumber, 1);
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinNumber);
    }
}
