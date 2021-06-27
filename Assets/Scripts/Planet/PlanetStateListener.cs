using UnityEngine;
using UnityEngine.Events;

namespace Planet
{
    [CreateAssetMenu(menuName = "Planet State Listener")]
    public class PlanetStateListener : ScriptableObject
    {
        public UnityEvent<PlanetState> OnPlanetStateChanged;
    }
}