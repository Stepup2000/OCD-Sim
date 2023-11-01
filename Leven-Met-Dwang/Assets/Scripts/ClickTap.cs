using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTap : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.25f;
    [SerializeField] private GameObject _waterSteam;
    private float _currentCooldown;

    private void Start()
    {
        ToggleWater();
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
            _waterSteam.SetActive(!_waterSteam.activeSelf);
            _currentCooldown = _cooldownDuration;
        }
    }
}
