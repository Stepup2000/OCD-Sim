using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class Book : MonoBehaviour
{
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float stationaryTime = 0.0f; // Tracks how long the object has been stationary
    private float timeTillStationary = 0.05f;
    private bool isMoving = false;
    private Rigidbody _myRigidbody;

    private void Start()
    {
        TryGetComponent<Rigidbody>(out _myRigidbody);
    }

    private void FixedUpdate()
    {
        if (lastPosition == transform.position && lastRotation == transform.rotation)
        {
            stationaryTime += Time.deltaTime; // Increment the stationary time
            if (isMoving != false && stationaryTime >= timeTillStationary) // Check if it's been stationary for x seconds
            {
                isMoving = false;
            }
        }
        else
        {
            stationaryTime = 0.0f; // Reset the stationary time if there's any movement
            isMoving = true;
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void StopMovement()
    {
        _myRigidbody.velocity = Vector3.zero;
        _myRigidbody.angularVelocity = Vector3.zero;
        _myRigidbody.isKinematic = false;
    }
}
