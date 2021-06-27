using System;
using UnityEngine;

[ExecuteAlways]
public class GlobeLine : MonoBehaviour
{
    public PolarCoordinate start;
    public PolarCoordinate end;
    public int increments = 10;


    public LineRenderer lr;
    private void Update()
    {
        if (lr == null) return;
        var increments = this.increments;
        
        Vector3[] points = new Vector3[increments];
        lr.positionCount = increments * Mathf.RoundToInt(PolarCoordinate.Angle(start, end));
        lr.useWorldSpace = true;
        
        float alt = start.altitude;
        PolarCoordinate next = start;
        for (int i = 0; i < increments; i++)
        {
            float t = i / (float)increments;
            points[i] = PolarCoordinate.Lerp(start, end, t);
        }
        lr.SetPositions(points);
    }
}