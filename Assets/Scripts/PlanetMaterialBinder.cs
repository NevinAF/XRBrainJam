using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlanetMaterialBinder : MonoBehaviour
{
    // Start is called before the first frame update
    

    public MeshRenderer mr;
    private static readonly int IceAmount = Shader.PropertyToID("_iceAmount");

    void Start()
    {
        this.mr = GetComponent<MeshRenderer>();
    }
    public void UpdateIceAmount(float amount)
    {
        mr.material.SetFloat(IceAmount, amount);
    }
}
