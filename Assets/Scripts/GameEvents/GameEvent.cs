using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    public PolarCoordinate globeLocation;
}