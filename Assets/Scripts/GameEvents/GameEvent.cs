using System;
using Planet;
using UnityEngine;

[CreateAssetMenu(menuName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    public PolarCoordinate globeLocation;
    public GameObject mapPrefab;
    public string sceneName;
}