using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPlaceChecker : MonoBehaviour
{
    public bool bookIsPlaced = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Book>()) bookIsPlaced = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Book>()) bookIsPlaced = false;
    }
}
