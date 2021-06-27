using System;
using Planet;
using UnityEngine;

[CreateAssetMenu(menuName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    public PolarCoordinate globeLocation;
    public GameObject mapPrefab;
    public EventImpactDefinition impact;
    
    [Serializable]
    public class EventImpactDefinition
    {
        [Tooltip("set to 0 for constant co2 emissions")]
        public float timespan;
        
        //[Tooltip("Will only use the curves if a timespan is specified.")]
        //public ParticleSystem.MinMaxCurve co2EmissionImpact = new ParticleSystem.MinMaxCurve() {mode = ParticleSystemCurveMode.Constant, curve = AnimationCurve.Linear(0,0, 1, 1)};
        
        
        public PlanetState impact;
        
        
        public bool HasTimespan => timespan > 0;
    }
}

public interface IImpact
{
    public PlanetState Impact { get; }
}

public class GameEventInstance : MonoBehaviour
{
    public GameEvent.EventImpactDefinition definition;
    public GameEventSolution solution;
        
    private void Start()
    {
        AddImpact();
    }

    private void OnDestroy()
    {
        RemoveImpact();
    }
    
    private void AddImpact()
    {
        
    }
    
    private void RemoveImpact()
    {
        
    }
}