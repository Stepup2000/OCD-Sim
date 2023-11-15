using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    private TMP_Text _UItext; // Reference to the TextMeshPro text component

    private void OnEnable()
    {
        // Get the TextMeshPro component from children GameObjects
        _UItext = GetComponentInChildren<TMP_Text>();

        // Subscribe the method ChangeUI to the OnUIChange event
        EventBus<OnUIChange>.Subscribe(ChangeUI);
    }

    public void OnDisable()
    {
        // Unsubscribe the method ChangeUI from the OnUIChange event
        EventBus<OnUIChange>.UnSubscribe(ChangeUI);
    }

    // Method to change the UI text based on received OnUIChange event
    private void ChangeUI(OnUIChange onUIChange)
    {
        // Check if the TextMeshPro component exists
        if (_UItext != null)
        {
            // Set the text of the TextMeshPro component to the value received in OnUIChange event
            _UItext.text = onUIChange.value;
        }
        else
        {
            // If the TextMeshPro component is not found, log a warning message
            Debug.Log("UIText not found");
        }
    }
}
