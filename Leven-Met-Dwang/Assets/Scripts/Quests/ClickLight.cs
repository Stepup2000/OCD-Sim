using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickLight : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.5f; // Duration for the cooldown period
    private float _currentCooldown; // Current cooldown time left

    // Called every frame
    private void Update()
    {
        // Update the cooldown timer if it's greater than zero
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime; // Reduce cooldown time based on elapsed time
        }
    }

    public void SendLightClickEvent()
    {
        // Check if the cooldown is over, allowing the action to be performed again
        if (_currentCooldown <= 0)
        {
            // If the cooldown is over, publish the event signaling a light click and play the sound effect
            EventBus<OnLightClicked>.Publish(new OnLightClicked());
            AudioManager.Instance.PlaySound("LightSwitch");

            // Reset the cooldown timer to the designated duration
            _currentCooldown = _cooldownDuration;
        }
    }
}
