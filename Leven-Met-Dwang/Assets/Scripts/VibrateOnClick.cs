using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrateOnClick : MonoBehaviour
{
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        //Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
        if (args.interactorObject.transform.CompareTag("LeftController")) VibrationManager.Instance.VibrateLeftController(0.2f, 0.1f);
        if (args.interactorObject.transform.CompareTag("RightController")) VibrationManager.Instance.VibrateRightController(0.2f, 0.1f);
    }
}
