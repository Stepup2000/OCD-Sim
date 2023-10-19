using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlaySound", 2, 2);  
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySound("Test", 0.8f, 1.2f);
        Debug.Log("AudioPlayed");
    }
}
