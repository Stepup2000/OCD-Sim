using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrateOnClick : MonoBehaviour
{
    // Called when an object starts hovering over this interactable
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Check if the interacting object has a specific tag (e.g., LeftController or RightController)
        if (args.interactorObject.transform.CompareTag("LeftController"))
        {
            // If the interacting object has the LeftController tag, vibrate the left controller
            VibrationManager.Instance.VibrateLeftController(amplitude: 0.2f, duration: 0.1f);
        }
        if (args.interactorObject.transform.CompareTag("RightController"))
        {
            // If the interacting object has the RightController tag, vibrate the right controller
            VibrationManager.Instance.VibrateRightController(amplitude: 0.2f, duration: 0.1f);
        }
    }
}
