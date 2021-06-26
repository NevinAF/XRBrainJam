using UnityEngine;

[ExecuteAlways]
public class GlobeElement : MonoBehaviour
{
    private void Update()
    {
        var pos = GlobeManager.CenterOfGlobe;
        transform.LookAt(pos);
    }
}