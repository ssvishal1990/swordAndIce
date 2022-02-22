using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    [SerializeField] Transform[] points;
    // Start is called before the first frame update

    private void Start()
    {
        setupLine(points);
    }
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void setupLine(Transform[] points){
        Debug.Log(points.Length);
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for(int i = 0 ; i < points.Length; i++){
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
