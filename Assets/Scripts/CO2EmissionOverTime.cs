using System.Collections;
using System.Collections.Generic;
using Planet;
using UnityEngine;

public class CO2EmissionOverTime : MonoBehaviour
{
    public float co2OverTime = 1;

   

    private void Update()
    {
        var changeInC02 = co2OverTime * Time.deltaTime;
        var state = SharedPlanetState.GlobalState.currentState;
        state.co2Emissions += changeInC02;
        state.co2Emissions = Mathf.Max(0, state.co2Emissions);
        SharedPlanetState.GlobalState.currentState = state;
        Debug.Log(SharedPlanetState.GlobalState.currentState.ToString());
    }
}