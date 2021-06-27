using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventSelector : MonoBehaviour
{
    public Image Selector;
    public float selectTime;
    public Color ActiveColor;
    public ScaleAxis scaleAxis;
    public enum ScaleAxis { None, X, Y, Z, XY, XZ, YZ, XYZ }

    private float timeCounter;
    private Vector3 MaxScale;
    private Color startColor;

    public UnityEvent OnSelected;

    public int numberEnter = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (numberEnter == 0)
        {
            timeCounter = selectTime;
            MaxScale = Selector.transform.localScale;
            Selector.transform.localScale = Vector3.zero;
            startColor = Selector.color;

            Selector.gameObject.SetActive(true);

        }
        numberEnter++;
        
    }

    private void OnTriggerStay(Collider other)
    {
        timeCounter -= Time.deltaTime;

        float progress = Mathf.Clamp01((1 - (timeCounter / selectTime)));

        if (timeCounter <= 0)
        {
            Selector.color = ActiveColor;
        }

        Vector3 scl = MaxScale;
        switch (scaleAxis)
        {
            case ScaleAxis.None:
                break;
            case ScaleAxis.X:
                scl.x *= progress;
                break;
            case ScaleAxis.Y:
                scl.y *= progress;
                break;
            case ScaleAxis.Z:
                scl.z *= progress;
                break;
            case ScaleAxis.XY:
                scl.x *= progress;
                scl.y *= progress;
                break;
            case ScaleAxis.XZ:
                scl.x *= progress;
                scl.z *= progress;
                break;
            case ScaleAxis.YZ:
                scl.y *= progress;
                scl.z *= progress;
                break;
            case ScaleAxis.XYZ:
                scl.x *= progress;
                scl.y *= progress;
                scl.z *= progress;
                break;
        }

        Debug.Log("Progress:: " + progress);

        Selector.transform.localScale = scl;
    }

    private void OnTriggerExit(Collider other)
    {
        numberEnter--;

        if (numberEnter == 0)
        {
            Selector.gameObject.SetActive(false);
            Selector.transform.localScale = MaxScale;
            Selector.color = startColor;

            if (timeCounter <= 0)
            {
                OnSelected.Invoke();
            }
        }

    }
}
