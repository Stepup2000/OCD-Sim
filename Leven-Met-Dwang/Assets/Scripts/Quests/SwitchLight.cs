using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private Light _myLight;

    private void OnEnable()
    {
        EventBus<OnLightClicked>.Subscribe(ToggleLight);
    }

    public void OnDisable()
    {
        EventBus<OnLightClicked>.UnSubscribe(ToggleLight);
    }

    private void ToggleLight(OnLightClicked onLightClicked)
    {
        if (_myLight != null) _myLight.enabled = !_myLight.enabled;
    }
}
