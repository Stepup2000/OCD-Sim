using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTap : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration = 0.5f;
    [SerializeField] private GameObject _waterSteam;
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
            EventBus<WashHand>.Publish(new WashHand());
            AudioManager.Instance.PlaySound("LightSwitch");

            // Reset the cooldown timer.
            _currentCooldown = _cooldownDuration;
        }
    }

    public void ToggleWater()
    {
        if (_waterSteam != null) _waterSteam.SetActive(!_waterSteam.activeSelf);
    }
}
