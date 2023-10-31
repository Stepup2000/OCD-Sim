using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;
    private XRPokeInteractor _xrPokeInteractor;

    private void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponent<XRPokeInteractor>();
        SetPokeAttachPoint();
    }

    private void SetPokeAttachPoint()
    {
        if (PokeAttachPoint == null) { return; }
        if (_xrPokeInteractor == null) {return; }

        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
