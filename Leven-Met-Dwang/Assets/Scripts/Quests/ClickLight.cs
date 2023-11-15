using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickLight : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.5f;
    private float _currentCooldown;

    private void Update()
    {
        // Update the cooldown timer.
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    public void SendLightClickEvent()
    {
        // Check if the cooldown is still active.
        if (_currentCooldown <= 0)
        {
            // If not, publish the event and play the sound.
            EventBus<OnLightClicked>.Publish(new OnLightClicked());
            AudioManager.Instance.PlaySound("LightSwitch");

            // Reset the cooldown timer.
            _currentCooldown = _cooldownDuration;
        }
    }
}

