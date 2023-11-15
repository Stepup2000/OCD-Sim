using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTap : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.25f; // Cooldown duration between toggles
    [SerializeField] private float _autoTurnOffDuration = 10f; // Duration before automatic turn-off
    [SerializeField] private GameObject _waterSteam; // Reference to the water steam GameObject
    [SerializeField] private AudioClip _loopSound; // Looping sound clip
    private AudioSource _audioSource; // Audio source component for playing sounds
    private float _currentCooldown; // Cooldown timer for toggling water
    private float _autoTurnOffTimer; // Timer for automatic turn-off
    private bool _isOn = true; // Flag to track if the water is on or off (start initially as off)

    private void Start()
    {
        ToggleWater(false); // Initially turn off the water
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.loop = true; // Set AudioSource to loop
        _audioSource.clip = _loopSound; // Assign the looping sound clip
    }

    private void Update()
    {
        // Update the cooldown timer for toggling water
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }

        // Update the auto turn-off timer
        if (_autoTurnOffTimer > 0)
        {
            _autoTurnOffTimer -= Time.deltaTime;
            if (_autoTurnOffTimer <= 0 && _isOn)
            {
                // Automatically turn off the faucet after the specified time
                ToggleWater(false);
            }
        }
    }

    public void ToggleWater(bool waterSound = true)
    {
        // Check if the cooldown for toggling is still active and the water steam reference is not null
        if (_currentCooldown <= 0 && _waterSteam != null)
        {
            _isOn = !_isOn; // Invert the flag to toggle water
            _waterSteam.SetActive(_isOn); // Activate or deactivate the water steam effect
            _currentCooldown = _cooldownDuration; // Set cooldown for the next toggle

            if (_isOn)
            {
                // Reset the auto turn-off timer only if the faucet is turned on
                _autoTurnOffTimer = _autoTurnOffDuration;

                // Play loop sound for water
                PlayWaterSound();

                // Start repeating the sound every second
                InvokeRepeating("PlayWaterSound", 0f, 1.45f);
            }
            else
            {
                // Stop the loop sound when water is turned off
                CancelInvoke("PlayWaterSound");
            }

            // Play the squeak sound on toggle, but only when it's turned on
            if (waterSound) AudioManager.Instance.PlaySound("Squeak");
        }
    }

    // Method to play the loop sound for water
    private void PlayWaterSound()
    {
        AudioManager.Instance.PlaySound("CraneSound");
    }
}
