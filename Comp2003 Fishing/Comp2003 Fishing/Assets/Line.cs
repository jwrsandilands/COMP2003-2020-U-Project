using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform lineTop;
    public Transform lineBottom;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, lineTop.position);
        lineRenderer.SetPosition(1, lineBottom.position);
        lineRenderer.SetWidth(.01f, .01f);

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, lineTop.transform.localPosition);
        lineRenderer.SetPosition(1, lineBottom.transform.localPosition);
    }
}
