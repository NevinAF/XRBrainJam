using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobeGrabHandler : MonoBehaviour
{
    public XRBaseInteractable interactable;
    public GameObject globe;
    public float radiusMultiplier = 1;
    public bool snapFollow;
    public float followSpeed = 10;
    private SphereCollider _sphereCollider;
    public float rotationSpeed = 1;
    public GameObject rotationGrabPoint;
    
    private bool isHeld;
    private Transform heldBy;

    private bool isRotating
    {
        get => _isRotating;
        set
        {
            _isRotating = value;
            (this.interactable as TwoHandGrabInteractable).trackPosition = !_isRotating;
        }
    }
    private Transform rotatedBy;
    private bool _isRotating;


    public Transform[] hands; 
    
    private void Awake()
    {
        
        interactable = GetComponent<XRBaseInteractable>();
        _sphereCollider = interactable.GetComponent<SphereCollider>();
        interactable.selectEntered.AddListener(selectEnterArg =>
        {
            if (!isHeld)
            {
                isHeld = true;
                this.heldBy = selectEnterArg.interactor.transform;
                rotatedBy = hands.FirstOrDefault(t => t != this.heldBy);
                Debug.Assert(rotatedBy != null);
                StartHolding();
            }
            else //if (!isRotating && (isHeld && selectEnterArg.interactor.transform != heldBy))
            {
                Debug.Assert(rotatedBy != null);
                Debug.Assert(selectEnterArg.interactor.transform == rotatedBy);
                isRotating = true;
                rotatedBy = selectEnterArg.interactable.transform;
                
            }
        }); 
        
        interactable.selectExited.AddListener(selectExitArg =>
        {
            if (isHeld && heldBy == selectExitArg.interactor.transform)
            {
                isHeld = false;
                isRotating = false;
                rotatedBy = null;
                this.heldBy = null;
                
                StopHolding();
            }

            if (isRotating && rotatedBy == selectExitArg.interactable.transform)
            {
                isRotating = false;
            }
        });
        rotationGrabPoint.SetActive(false);
    }

    private void StopHolding()
    {
        isRotating = false;
        rotatedBy = null;
        rotationGrabPoint.SetActive(false);
        StopAllCoroutines();
        interactable.transform.position = globe.transform.position;
    }

    private void StartHolding()
    {
        rotationGrabPoint.SetActive(true);
        rotatedBy = hands.FirstOrDefault(t => t != heldBy);
        StartCoroutine(FollowHeldObject());
    }

    private void Update()
    {
        if (rotatedBy != null)
        {
            var pos = globe.GetComponent<Rigidbody>().position + (globe.transform.forward * .5f);
            var rDir= interactable.transform.position - this.rotatedBy.position;
            var newPos = Quaternion.LookRotation(rDir) * pos;
            globe.transform.Find("Test").position = newPos;
            Debug.DrawLine(globe.transform.position, pos, Color.blue);
            Debug.DrawLine(globe.transform.position, newPos, Color.red);
        }
    }
    
    IEnumerator FollowHeldObject()
    {
        while (isHeld)
        {
            if (isRotating)
            {
                var rDir= interactable.transform.position - this.rotatedBy.position;
                UpdateRotation();
                 Debug.Log("Rotating");
                // var pos = globe.transform.position + (Vector3.forward * 3);
                // var newPos = Quaternion.LookRotation(rDir) * pos;
                // globe.transform.LookAt(newPos);
                // globe.transform.forward = newPos - globe.transform.position;
                // Debug.DrawLine(globe.transform.position, pos, Color.blue);
                // Debug.DrawLine(globe.transform.position, newPos, Color.red);
            }
            else
            {
                if (snapFollow)
                {
                    var dir = globe.transform.position - heldBy.position;
                
                    globe.transform.position = interactable.transform.position + (dir * (_sphereCollider.radius * radiusMultiplier));

                    UpdateRotation();
                    if(!isRotating) this.rotationGrabPoint.transform.parent.LookAt(rotatedBy);
                    
                
                }
                else
                {
                    throw new NotImplementedException("ill come back if I have time");
                }
            }
            

          
            
            yield return null;
        }
    }

    private Quaternion lastRotation;
    private void UpdateRotation()
    {
        var thisRotation = interactable.transform.rotation;
        var angle = Quaternion.Angle(lastRotation, thisRotation);
        lastRotation = thisRotation;
        globe.transform.Rotate(Vector3.up, angle);
    }
}
