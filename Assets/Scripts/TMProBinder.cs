using System;

public class TMProBinder : TextBinder
{
    public TMPro.TextMeshProUGUI textElement;

    private void Awake()
    {
        textElement = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public override string text
    {
        get => textElement.text;
        set => textElement.text = value;
    }
}