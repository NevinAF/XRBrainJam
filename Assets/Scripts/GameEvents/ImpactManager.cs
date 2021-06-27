using System.Collections.Generic;
using Planet;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public List<IImpact> impacts;
    public float impactFrequency = 1;

    private void Start()
    {
        InvokeRepeating("UpdateImpacts", 0, impactFrequency);
    }

    private void UpdateImpacts()
    {
        PlanetState newState = SharedPlanetState.GlobalState.currentState;
        foreach (var impact in impacts)
        {
            newState.co2Emissions += impact.Impact.co2Emissions;
            newState.globalTemperature += impact.Impact.globalTemperature;
            newState.iceCapAmount += impact.Impact.iceCapAmount;
        }
        SharedPlanetState.GlobalState.currentState = newState;
    }
}