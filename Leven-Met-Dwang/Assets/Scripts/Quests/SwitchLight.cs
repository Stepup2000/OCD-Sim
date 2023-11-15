using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private Light _myLight; // Reference to the Light component

    // This method is called when the GameObject this script is attached to becomes active/enabled
    private void OnEnable()
    {
        // Subscribe to the OnLightClicked event when this GameObject is enabled
        EventBus<OnLightClicked>.Subscribe(ToggleLight);
    }

    // This method is called when the GameObject this script is attached to becomes inactive/disabled
    public void OnDisable()
    {
        // Unsubscribe from the OnLightClicked event when this GameObject is disabled
        EventBus<OnLightClicked>.UnSubscribe(ToggleLight);
    }

    // This method toggles the state of the Light component based on the OnLightClicked event
    private void ToggleLight(OnLightClicked onLightClicked)
    {
        // Check if the Light component is not null
        if (_myLight != null)
        {
            // Toggle the enabled state of the Light component
            _myLight.enabled = !_myLight.enabled;
        }
    }
}
