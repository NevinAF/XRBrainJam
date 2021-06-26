using System;
using UnityEngine;

[ExecuteAlways]
public class PolarPosition : MonoBehaviour
{
    public PolarCoordinate pc;

    private void Update()
    {
        transform.localPosition = pc.PolarToWorld();
    }
}