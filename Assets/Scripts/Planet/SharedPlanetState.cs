using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using Planet;
using UnityEditor;
#endif
using UnityEngine;

namespace Planet
{
    [CreateAssetMenu(menuName = "Globals/Global Planet State")]
    public class SharedPlanetState : ScriptableObject
    {
        private static SharedPlanetState _instance;

        public static SharedPlanetState GlobalState
        {
            get
            {
                if (_instance==null)
                {
                    _instance = Resources.Load<SharedPlanetState>("Shared Planet State");
                    if (_instance == null)
                    {
                        _instance = ScriptableObject.CreateInstance<SharedPlanetState>();
                    }
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }


        [DisableInPlay]
        [SerializeField] private PlanetState _state;


        public PlanetState currentState
        {
            get => _state;
            set
            {
                if (value.Equals(_state) == false)
                {
                    _state = value;
                    BroadcastState();
                }
                _state = value;
            }
        }

        public List<PlanetStateListener> listeners;

        public bool ContainsListener(PlanetStateListener listener)
        {
            return listeners.Contains(listener);
        }
        public void AddListener(PlanetStateListener listener)
        {
            if (ContainsListener(listener)) return;
            listeners.Add(listener);
            listener.OnPlanetStateChanged?.Invoke(_state);   
        }
        public void RemoveListener(PlanetStateListener listener)
        {
            listeners.Remove(listener);
        }
        public void SetState(PlanetState newState, bool suppressEvent)
        {
            if (!suppressEvent)
            {
                currentState = newState;
            }
            else
            {
                _state = newState;
            }
        }

        public void BroadcastState()
        {
            foreach (var stateListener in listeners)
            {
                stateListener.OnPlanetStateChanged?.Invoke(_state);
            }
        }
        public void ResetPlanetToDefaultState()
        {
            currentState = new PlanetState()
            {
                co2Emissions = 0,
                globalTemperature = PlanetState.MIN_GLOBAL_TEMPERATURE,
                iceCapAmount = 1
            };
        }
    }
}


public class DisableInPlay : PropertyAttribute
{
    
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(DisableInPlay))]
public class DisableInPlayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginDisabledGroup(Application.isPlaying);
        base.OnGUI(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}

[CustomEditor(typeof(SharedPlanetState))]
public class SharedPlanetStateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        if (EditorGUI.EndChangeCheck())
        {
            (target as SharedPlanetState).BroadcastState();
        }
        
        
    }
}
#endif