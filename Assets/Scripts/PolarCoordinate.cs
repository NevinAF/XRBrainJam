using System;
using UnityEngine;

[Serializable]
public struct PolarCoordinate
{
    public float longitude;
    public float latitude;
    public float altitude;
    
    
    public static  PolarCoordinate operator +(PolarCoordinate p1, PolarCoordinate p2)
    {
        return new PolarCoordinate()
        {
            longitude = p1.longitude + p2.longitude,
            latitude = p1.latitude + p2.latitude,
            altitude = p1.altitude + p2.altitude
        };
    }
    public static  PolarCoordinate operator -(PolarCoordinate p1, PolarCoordinate p2)
    {
        return new PolarCoordinate()
        {
            longitude = p1.longitude - p2.longitude,
            latitude = p1.latitude - p2.latitude,
            altitude = p1.altitude - p2.altitude
        };
    }
    public static  PolarCoordinate operator *(PolarCoordinate p1, PolarCoordinate p2)
    {
        return new PolarCoordinate()
        {
            longitude = p1.longitude * p2.longitude,
            latitude = p1.latitude * p2.latitude,
            altitude = p1.altitude * p2.altitude
        };
    }
     
    public Vector3 PolarToWorld(PolarCoordinate polar)
    {
        Vector3 right = Vector3.right;
        Vector3 down = Vector3.down;
        var radius = WorldConfig.Instance.worldMapRadius;
        var identity = Vector3.forward * (radius + polar.altitude);
        var position = Quaternion.Euler(polar.longitude, polar.latitude, 0) * identity;
        return position;
    }

    // public PolarCoordinate WorldToPolar(Vector3 world)
    // {
    //     
    // }
}