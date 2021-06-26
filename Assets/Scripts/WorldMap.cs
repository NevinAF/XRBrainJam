using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldMap : MonoBehaviour
{
    public UnityEvent<UnityEngine.Object> _event;
    public Transform center;
    public Transform test;

    public GameObject globe;

    public PolarCoordinate coordinate;
    private void Start()
    {
        _event.AddListener(obj =>
        {
            Debug.Log(obj.name);
        });
        Debug.Assert(WorldConfig.Instance != null);
        globe.transform.localScale = Vector3.one * WorldConfig.Instance.worldMapRadius;
        globe.transform.parent = center;
        globe.transform.localPosition =  Vector3.zero;
       
        var radius = WorldConfig.Instance.worldMapRadius;
        var identity = Vector3.forward * radius;
        test.transform.parent = center;
        test.transform.localPosition = identity;

        var pos = coordinate.PolarToWorld(coordinate);
        test.transform.localPosition = pos;
    }

    private void Update()
    {
        var pos = coordinate.PolarToWorld(coordinate);
        test.localPosition = pos;
        
        test.LookAt(globe.transform.position);
    }
}