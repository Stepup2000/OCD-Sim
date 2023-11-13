using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTap : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.25f;
    [SerializeField] private GameObject _waterSteam;
    [SerializeField] private AudioClip _loopSound; // Sound to play
    private AudioSource _audioSource; // AudioSource component reference
    private float _currentCooldown;
    private bool _isOn = true;

    private void Start()
    {
        ToggleWater();
        _audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component
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
    }

    public void ToggleWater()
    {
        // Check if the cooldown is still active.
        if (_currentCooldown <= 0 && _waterSteam != null)
        {
            _isOn = !_isOn;
            _waterSteam.SetActive(_isOn);
            _currentCooldown = _cooldownDuration;
            AudioManager.Instance.PlaySound("Squeak");

            if (_isOn)
            {
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
        }
    }

    // Method to play the loop sound every second
    private void PlayWaterSound()
    {
        AudioManager.Instance.PlaySound("CraneSound");
    }
}
