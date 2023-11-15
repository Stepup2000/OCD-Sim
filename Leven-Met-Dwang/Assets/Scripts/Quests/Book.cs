using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class Book : MonoBehaviour
{
    private Vector3 lastPosition; // Records the object's last position
    private Quaternion lastRotation; // Records the object's last rotation
    private float stationaryTime = 0.0f; // Tracks how long the object has been stationary
    private float timeTillStationary = 0.05f; // Time threshold for considering the object as stationary
    private bool isMoving = false; // Flag indicating if the object is currently moving
    private Rigidbody _myRigidbody; // Reference to the object's Rigidbody component

    private void Start()
    {
        // Attempt to get the Rigidbody component
        TryGetComponent<Rigidbody>(out _myRigidbody);
    }

    private void FixedUpdate()
    {
        // Check if the object is stationary by comparing its current position and rotation with the last frame
        if (lastPosition == transform.position && lastRotation == transform.rotation)
        {
            stationaryTime += Time.deltaTime; // Increment the stationary time

            // Check if it's been stationary for a certain duration and update the 'isMoving' flag
            if (isMoving != false && stationaryTime >= timeTillStationary)
            {
                isMoving = false; // Object is considered stationary
            }
        }
        else
        {
            stationaryTime = 0.0f; // Reset the stationary time if there's any movement
            isMoving = true;
        }

        // Update the last recorded position and rotation for the next frame comparison
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public void StopMovement()
    {
        // Reset velocity and angular velocity, allowing the object to stop moving abruptly
        _myRigidbody.velocity = Vector3.zero;
        _myRigidbody.angularVelocity = Vector3.zero;
        _myRigidbody.isKinematic = false;
    }
}
