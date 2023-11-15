using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        // Prevents the attached GameObject from being destroyed when loading a new scene
        DontDestroyOnLoad(transform.gameObject);
    }
}
