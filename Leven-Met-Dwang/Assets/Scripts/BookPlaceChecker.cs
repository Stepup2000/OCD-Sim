using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlaceChecker : MonoBehaviour
{
    public bool bookIsPlaced = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Book>())
        {
            // Get the Transform component of the other GameObject
            Transform otherTransform = other.transform;

            // Check the rotation of the other GameObject's Transform
            if (IsFacingForward(otherTransform))
            {
                // The other GameObject is facing forward
                bookIsPlaced = true;
            }
            else
            {
                // The other GameObject is not facing forward
                bookIsPlaced = false;
            }
        }
    }

    // Function to check if a Transform is facing forward
    bool IsFacingForward(Transform transform)
    {
        // Define a threshold angle for facing forward
        float thresholdAngle = 30.0f; // Adjust this value as needed

        // Calculate the angle between the forward vector of the transform
        // and the forward direction (e.g., Vector3.forward) in degrees
        float angle = Vector3.Angle(transform.forward, Vector3.forward);

        // Check if the angle is within the threshold for facing forward
        return angle <= thresholdAngle;
    }
}