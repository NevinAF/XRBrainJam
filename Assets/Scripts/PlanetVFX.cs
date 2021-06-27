using System;
using System.Collections;
using System.Collections.Generic;
using Globe;
using UnityEngine;
using UnityEngine.VFX;

public class PlanetVFX : MonoBehaviour
{
    [Range(0.001f, 2)]
    public float amountScalar = 1;
    public float maxAmount = 2000;
    public float atmosphereOffset = 1;
    private void Awake()
    {
     this.effect = gameObject.GetComponent<VisualEffect>();
    }

    public VisualEffect effect;

  

    public void SetCO2Emission(float amount)
    {
           effect.SetFloat("CO2 Emission", Mathf.Min(maxAmount, amount * amountScalar));
    }

    private void OnEnable()
    {
        effect.SetFloat("Radius", WorldConfig.Instance.worldMapRadius + atmosphereOffset);
        effect.SetVector3("Center", GlobeManager.CenterOfGlobe);
    }
}
