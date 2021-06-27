using System;
using UnityEngine;

[ExecuteAlways]
public class PolarPosition : MonoBehaviour
{
    public PolarCoordinate position;

    private void Update()
    {
        transform.localPosition = position.PolarToWorld();
    }
}