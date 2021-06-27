using System;
using Planet;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlanetHealthUpdater : MonoBehaviour
    {
        
        public float meltBeginTemperature = 0;
        public float absoluteMaxTemperature = 10000;

        public float co2Threshold = 100;
        public float co2Max = 2000;
        
        [Range(0,10)]
        public float co2TemperatureIncreaseRate = 5;
        [Range(0,-10)]
        public float co2TemperatureDecreaseRate = -5;
        
        [Range(0, 100)]
        public float maxMeltRate = 5;
        public AnimationCurve meltCurve = AnimationCurve.Linear(0, 0, 1, 1);
        
        public bool isTempIncreasing;
        
        public float TemperatureChangeRate { get; set; }
        
        private void Update()
        {
            var state = SharedPlanetState.GlobalState.currentState;
            var co2 =state.co2Emissions;
            bool increasing = co2 > co2Threshold;
            isTempIncreasing = increasing;
            if (increasing)
            {
                var tI = Mathf.InverseLerp(co2Threshold, co2Max, co2);
                var finalI = Mathf.Lerp(0, co2TemperatureIncreaseRate, tI);
                state.globalTemperature += (finalI * Time.deltaTime);
            }
            else
            {
                var tD = Mathf.InverseLerp(0, co2Threshold, co2);
                var finalD = Mathf.Lerp(0, co2TemperatureDecreaseRate, tD);
                state.globalTemperature += (finalD * Time.deltaTime);
            }

            bool isMelting = state.globalTemperature > meltBeginTemperature;
            var tMelt = Mathf.InverseLerp(meltBeginTemperature, absoluteMaxTemperature, state.globalTemperature);
            tMelt = meltCurve.Evaluate(tMelt);
            var meltRate = tMelt * (maxMeltRate/100f) * Time.deltaTime;
            var iceLevel = state.iceCapAmount;
            iceLevel -= meltRate;
            state.iceCapAmount = iceLevel;

            state.globalTemperature = Mathf.Clamp(state.globalTemperature, 0, absoluteMaxTemperature );
            state.iceCapAmount = Mathf.Clamp01(state.iceCapAmount);
            SharedPlanetState.GlobalState.currentState = state;
            
        }
    }
}