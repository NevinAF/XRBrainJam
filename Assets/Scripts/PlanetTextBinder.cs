using System;
using UnityEngine;

public class PlanetTextBinder : MonoBehaviour
{
    public TextBinder co2Element;
    public string co2Format = "CO2: {0}";
    
    public TextBinder temperatureElement;
    public string temperatureFormat = "Temperature: {0} degrees";
    
    public TextBinder iceElement;
    public string iceFormat = "{0:p} Glacier Melt";

    public void UpdateCO2(float amount)
    {
        if (co2Element == null) return;
        co2Element.text = String.Format(co2Format, amount);
    }

    public void UpdateTemp(float amount)
    {
        if (temperatureElement == null) return;
        temperatureElement.text = String.Format(temperatureFormat, amount);
    }

    public void UpdateIce(float amount)
    {
        if (iceElement == null) return;
        iceElement.text = String.Format(iceFormat, 1 - amount);
    }
}

public abstract class TextBinder : MonoBehaviour
{
    public abstract  string text { get; set; }
}