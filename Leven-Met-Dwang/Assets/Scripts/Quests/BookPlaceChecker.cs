using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookPlaceChecker : MonoBehaviour
{
    public bool bookIsPlaced = false;

    private void OnTriggerStay(Collider other)
    {
        Book book = other.GetComponent<Book>();
        if (book != null)
        {
            if (book.IsMoving() == false)
            {
                // Get the Transform component of the other GameObject (the book)
                Transform bookTransform = other.transform;

                // Check if the book is roughly aligned with the checker
                if (IsAlignedWithChecker(bookTransform, transform, 0.1f))
                {
                    bookIsPlaced = true;
                    return;
                }
                else
                {
                    // The book is not aligned with the checker within the allowed error
                    bookIsPlaced = false;
                }

                //If its close enough teleport it tot the correct spot
                if (IsAlignedWithChecker(bookTransform, transform, 5.0f))
                {
                    // The book is roughly aligned with the checker within the allowed error
                    bookTransform.position = new Vector3(transform.position.x, bookTransform.position.y, transform.position.z);
                    bookTransform.rotation = RoundRotationToNearest90Degrees(bookTransform.rotation);
                    book.StopMovement();
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