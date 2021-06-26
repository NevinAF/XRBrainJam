using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Grid : MonoBehaviour
{
    public int divisions = 15;
    public float altitude = -3;
    public LineRenderer lr;
    public void Update()
    {
        if (lr == null) return;
        List<Vector3> pnts = new List<Vector3>(); 
        PolarCoordinate[,] points = new PolarCoordinate[divisions,divisions];
        for (int la = 0; la < divisions; la++)
        {
            float laDegrees = la * divisions;
            
            for (int l = 0; l < divisions; l++)
            {
                float loDegrees = l * divisions;
                PolarCoordinate origin = new PolarCoordinate(){latitude = laDegrees, longitude = loDegrees, altitude = altitude};
                for (int lo = 0; lo < 360; lo++)
                {
                    PolarCoordinate next = new PolarCoordinate() {latitude = laDegrees, longitude = loDegrees + lo, altitude = altitude};
                    pnts.Add(next.PolarToWorld());
                }
            }
            
        }

        lr.positionCount = divisions;
        lr.SetPositions(pnts.ToArray());

    }
}