using System;
using UnityEngine;

[CreateAssetMenu(menuName = "World Config")]
public class WorldConfig : ScriptableObject
{
    public float worldMapRadius = 10;
    
    private static WorldConfig _instance;

    public static WorldConfig Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = Resources.Load<WorldConfig>("World Config");
            }
            return _instance;
        }
    }
}