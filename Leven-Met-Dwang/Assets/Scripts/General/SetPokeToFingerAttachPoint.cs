using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint; // Reference to the attach point for the poke interactor
    private XRPokeInteractor _xrPokeInteractor; // Reference to the XR Poke Interactor component

    private void Start()
    {
        // Get the XR Poke Interactor component from the parent's parent GameObject
        _xrPokeInteractor = transform.parent.parent.GetComponent<XRPokeInteractor>();

        // Set the poke attach point
        SetPokeAttachPoint();
    }

    // Method to set the poke attach point
    private void SetPokeAttachPoint()
    {
        // Return if the poke attach point or the XR Poke Interactor is null
        if (PokeAttachPoint == null) { return; }
        if (_xrPokeInteractor == null) { return; }

        // Set the attach transform of the XR Poke Interactor to the specified attach point
        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
