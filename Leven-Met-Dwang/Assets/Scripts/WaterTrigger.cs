using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.25f;
    private float _currentCooldown;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the cooldown is still active.
        if (_currentCooldown <= 0)
        {
            // If not, publish the event and play the sound.
            EventBus<WashHand>.Publish(new WashHand());

            // Reset the cooldown timer.
            _currentCooldown = _cooldownDuration;
        }
    }

    private void Update()
    {
        // Update the cooldown timer.
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
}
