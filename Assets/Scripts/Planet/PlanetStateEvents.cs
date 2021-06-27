using System;
using UnityEngine;
using UnityEngine.Events;

namespace Planet
{
    public class PlanetStateEvents : MonoBehaviour
    {
        [SerializeField]
        private PlanetStateListener listener;

        [Tooltip("If disabled then the event will only be called when a user has added the listener to the shared planet asset from the editor. It can be found in the resources folder")]
        public bool autoRegisterListener = true;

        public UnityEvent<float> OnIceAmountChanged;
        public UnityEvent<float> OnCO2AmountChanged;
        public UnityEvent<float> OnTemperatureChanged;

        public float GlobalTemperature => _localCache.globalTemperature;
        public float IceCapAmount => _localCache.iceCapAmount;
        public float CO2Emissions => _localCache.co2Emissions;
        
        private PlanetState _localCache;
        
        private void Awake()
        {
            if(listener == null)Debug.LogError("Planet State Events Missing a Listener", this);
            
            listener.OnPlanetStateChanged.AddListener(newState =>
            {
                CheckForEvent(newState.globalTemperature, _localCache.globalTemperature, OnTemperatureChanged);
                CheckForEvent(newState.co2Emissions, _localCache.co2Emissions, OnCO2AmountChanged);
                CheckForEvent(newState.iceCapAmount, _localCache.iceCapAmount, OnIceAmountChanged);
                _localCache = newState;
            });
            if (autoRegisterListener)
                SharedPlanetState.GlobalState.AddListener(listener);
            else if(SharedPlanetState.GlobalState.ContainsListener(listener)==false)
                Debug.LogWarning(
                    $"The Planet State Event object's listener {listener.name} is unregistered and will not be called",
                    this);
        }
        
        private void CheckForEvent(float newState, float cachedState, UnityEvent<float> unityEvent)
        {
            if (Math.Abs(newState - cachedState) > Mathf.Epsilon)
            {
                unityEvent?.Invoke(newState);
            }
        }
    }
}