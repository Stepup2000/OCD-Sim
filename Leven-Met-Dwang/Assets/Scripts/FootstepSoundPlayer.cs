using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundPlayer : MonoBehaviour
{
    private float timeSinceLastStep; // Time counter for footsteps

    public float footstepInterval = 0.5f; // Time interval between footsteps

    private void Update()
    {
        // Check if the object is moving (you can modify this condition as needed)
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            // Update the time counter
            timeSinceLastStep += Time.deltaTime;

            // Check if it's time to play another footstep sound
            if (timeSinceLastStep >= footstepInterval)
            {
                // Play the footstep sound
                AudioManager.Instance.PlaySound("Footstep");
                timeSinceLastStep = 0f; // Reset the timer
            }
        }
        else
        {
            // Reset the timer if the object is not moving
            timeSinceLastStep = footstepInterval;
        }
    }
}
