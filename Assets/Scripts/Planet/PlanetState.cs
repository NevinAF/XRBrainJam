using System;
using UnityEngine;

namespace Planet
{
    [System.Serializable]
    public struct PlanetState : IEquatable<PlanetState>
    {
        [Tooltip("CO2 Emission measured in volume/time")]
        public float co2Emissions;
        
        [Tooltip("Remaining percentage of Ice Caps from 0-1"), Range(0,1)]
        public float iceCapAmount;

        [Tooltip("The planet's global temperature, measured in TBD"), Range(MIN_GLOBAL_TEMPERATURE, MAX_GLOBAL_TEMPERATURE)]
        public float globalTemperature;


        public const float MIN_GLOBAL_TEMPERATURE = 10;
        public const float MAX_GLOBAL_TEMPERATURE = 100f;

        public bool Equals(PlanetState other)
        {
            return co2Emissions.Equals(other.co2Emissions) && iceCapAmount.Equals(other.iceCapAmount) && globalTemperature.Equals(other.globalTemperature);
        }

        public override bool Equals(object obj)
        {
            return obj is PlanetState other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = co2Emissions.GetHashCode();
                hashCode = (hashCode * 397) ^ iceCapAmount.GetHashCode();
                hashCode = (hashCode * 397) ^ globalTemperature.GetHashCode();
                return hashCode;
            }
        }
    }
}