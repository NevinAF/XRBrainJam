using System;
using Globe;
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
    public static  PolarCoordinate operator /(PolarCoordinate p1, PolarCoordinate p2)
    {
        return new PolarCoordinate()
        {
            longitude = p1.longitude / p2.longitude,
            latitude = p1.latitude   / p2.latitude,
            altitude = p1.altitude   / p2.altitude
        };
    }

    public static Vector3 Lerp(PolarCoordinate p1, PolarCoordinate p2, float t)
    {
        var pivot = GlobeManager.CenterOfGlobe;
        var pos1 = p1.PolarToWorld();
        var dir1 = pos1 - pivot;
        var pos2 = p2.PolarToWorld();
        var dir2 = pos2 - pivot;
        var rotation = Quaternion.FromToRotation(dir1, dir2);
        var result = Quaternion.Lerp(Quaternion.identity, rotation, t);
        var dir = result * dir1;
        return pivot + dir;
    }

    public static float Angle(PolarCoordinate p1, PolarCoordinate p2)
    {
        var pivot = GlobeManager.CenterOfGlobe;
        var pos1 = p1.PolarToWorld();
        var dir1 = pos1 - pivot;
        var pos2 = p2.PolarToWorld();
        var dir2 = pos2 - pivot;
        return Vector3.Angle(dir1, dir2);
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

    public Vector3 PolarToWorld()
    {
        Vector3 right = Vector3.right;
        Vector3 down = Vector3.down;
        var radius = WorldConfig.Instance.worldMapRadius;
        var identity = Vector3.forward * (radius + altitude);
        var position = Quaternion.Euler(longitude, latitude, 0) * identity;
        return position;
    }
    
}