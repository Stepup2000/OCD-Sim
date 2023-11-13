using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTap : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.25f;
    [SerializeField] private float _autoTurnOffDuration = 10f;
    [SerializeField] private GameObject _waterSteam;
    [SerializeField] private AudioClip _loopSound;
    private AudioSource _audioSource;
    private float _currentCooldown;
    private float _autoTurnOffTimer;
    private bool _isOn = true; // Start initially as off

    private void Start()
    {
        ToggleWater(false);
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.clip = _loopSound;
    }

    private void Update()
    {
        // Update the cooldown timer.
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }

        // Update the auto turn-off timer.
        if (_autoTurnOffTimer > 0)
        {
            _autoTurnOffTimer -= Time.deltaTime;
            if (_autoTurnOffTimer <= 0 && _isOn)
            {
                // Automatically turn off the faucet after the specified time.
                ToggleWater(false);
            }
        }
    }

    public void ToggleWater(bool waterSound = true)
    {
        // Check if the cooldown is still active.
        if (_currentCooldown <= 0 && _waterSteam != null)
        {
            _isOn = !_isOn;
            _waterSteam.SetActive(_isOn);
            _currentCooldown = _cooldownDuration;

            if (_isOn)
            {
                // Reset the auto turn-off timer only if the faucet is turned on.
                _autoTurnOffTimer = _autoTurnOffDuration;
                // Play loop sound
                PlayWaterSound();
                // Start repeating the sound every second
                InvokeRepeating("PlayWaterSound", 0f, 1.45f);
            }
            else
            {
                // Stop the sound when water is turned off
                CancelInvoke("PlayWaterSound");
            }

            //Play the squeak sound on toggle, but only when it's on
            if (waterSound) AudioManager.Instance.PlaySound("Squeak");
        }
    }

    // Method to play the loop sound every second
    private void PlayWaterSound()
    {
        AudioManager.Instance.PlaySound("CraneSound");
    }
}
