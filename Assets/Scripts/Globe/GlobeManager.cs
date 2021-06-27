using Planet;
using UnityEngine;

namespace Globe
{
    public class GlobeManager : MonoBehaviour
    {
        private static GlobeManager _instance;

        public static GlobeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GlobeManager>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public GameObject globe;

        private void Awake()
        {
            if (_instance != null && _instance != this )
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                SharedPlanetState.GlobalState.ResetPlanetToDefaultState();
            }
        }


        private void Start()
        {
            if (globe == null)
            {
                globe = new GameObject("Globe");
            }
        }

        public static Vector3 CenterOfGlobe => Instance.globe.transform.position;
        public static Transform Globe => Instance.globe.transform;
    }
}