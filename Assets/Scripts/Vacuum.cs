using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float range;
    public float width;
    public Transform CastPositionAndDirection;
    public LayerMask layerMask;
    public AnimationCurve ForceDistanceCurve;
    public AnimationCurve ScaleDistanceCurve;


    private bool isactivated;
    // Start is called before the first frame update
    void Start()
    {
        isactivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isactivated)
        {
            RaycastHit[] hits = Physics.SphereCastAll(CastPositionAndDirection.position, width, CastPositionAndDirection.forward, range, layerMask);

            foreach(var hit in hits)
            {
                if (hit.rigidbody != null)
                {
                    float distance = Vector3.Distance(hit.transform.position, CastPositionAndDirection.position);

                    hit.rigidbody.AddForce(
                        (CastPositionAndDirection.position - hit.transform.position).normalized * ForceDistanceCurve.Evaluate(distance), ForceMode.Force);

                    float scale = ScaleDistanceCurve.Evaluate(distance); ;
                    if (scale < 0.1)
                        Destroy(hit.transform.gameObject);

                    if (hit.transform.localScale.y > scale)
                        hit.transform.localScale = Vector3.one * scale;
                }
                else
                {
                    Debug.LogWarning("Vacuum is designed to interact will all objects on it's layer mask. There is an collider in the hit data without a rigid body.");
                }
            }
        }
    }

    public void Activate()
    {
        isactivated = true;
    }

    public void Deactivate()
    {
        isactivated = false;
    }
}
