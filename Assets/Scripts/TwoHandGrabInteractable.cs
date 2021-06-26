using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondHandGrapPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion initailAttachRotation;
    public enum TwoHandRotationType { None, First, Second }
    public TwoHandRotationType rotationType = TwoHandRotationType.None;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        foreach (var item in secondHandGrapPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
        {
            // Compute Rotation
            selectingInteractor.attachTransform.rotation = GetTwoHandRotation();

        }
        base.ProcessInteractable(updatePhase);
    }

    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation = Quaternion.identity;
        switch (rotationType)
        {
            case TwoHandRotationType.None:
                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
                break;
            case TwoHandRotationType.First:
                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
                break;
            case TwoHandRotationType.Second:
                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
                break;
        }
        return targetRotation;
    }

    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        if (selectingInteractor)
        secondInteractor = interactor;
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        secondInteractor = null;
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        secondInteractor = null;
        interactor.attachTransform.localRotation = initailAttachRotation;
    }

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        initailAttachRotation = interactor.attachTransform.localRotation;
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }


}
