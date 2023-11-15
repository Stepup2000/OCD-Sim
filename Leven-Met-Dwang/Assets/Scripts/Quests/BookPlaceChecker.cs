using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlaceChecker : MonoBehaviour
{
    public bool bookIsPlaced = false; // Flag indicating if the book is correctly placed

    // Called when a Collider stays within the trigger area
    private void OnTriggerStay(Collider other)
    {
        Book book = other.GetComponent<Book>();
        if (book != null)
        {
            if (!book.IsMoving())
            {
                Transform bookTransform = other.transform;

                // Check if the book is roughly aligned with the checker within a small error margin
                if (IsAlignedWithChecker(bookTransform, transform, 0.1f))
                {
                    bookIsPlaced = true; // Book is placed correctly
                    return;
                }
                else
                {
                    // The book is not aligned with the checker within the allowed error
                    bookIsPlaced = false;
                }

                // If it's close enough, teleport it to the correct spot and align it properly
                if (IsAlignedWithChecker(bookTransform, transform, 5.0f))
                {
                    // Teleport the book to the correct spot
                    bookTransform.position = new Vector3(transform.position.x, bookTransform.position.y, transform.position.z);
                    bookTransform.rotation = RoundRotationToNearest90Degrees(bookTransform.rotation);
                    // Stop the book's movement abruptly
                    book.StopMovement();
                    // Play a sound indicating successful placement
                    AudioManager.Instance.PlaySound("BookSound");
                }
            }
        }
    }

    // Function to round a rotation to the nearest 90 degrees
    Quaternion RoundRotationToNearest90Degrees(Quaternion rotation)
    {
        float y = rotation.eulerAngles.y;
        float roundedY = Mathf.Round(y / 90.0f) * 90.0f;
        return Quaternion.Euler(0, roundedY, 0);
    }

    // Function to check if a Transform is roughly aligned with another Transform within a certain error margin
    bool IsAlignedWithChecker(Transform bookTransform, Transform checkerTransform, float allowedError)
    {
        // Calculate the angle between the forward vectors of the two transforms in degrees
        float angle = Vector3.Angle(bookTransform.forward, checkerTransform.forward);

        // Check if the angle is within the allowed error
        return Mathf.Abs(angle) <= allowedError;
    }
}
