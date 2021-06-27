using System;
using System.Collections;
using System.Collections.Generic;
using Globe;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobeGrabPoint : MonoBehaviour
{
    public XRBaseInteractable interactable;

    

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEnter);
    }

    private void OnSelectEnter(SelectEnterEventArgs selectEnterArgs)
    {
            transform.position = selectEnterArgs.interactor.transform.position;
            var gloobeCenter = interactable.transform.position;
            var dir = gloobeCenter - transform.position;
            transform.rotation = Quaternion.LookRotation(dir, selectEnterArgs.interactor.transform.up);
        
    }
}
