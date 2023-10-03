using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickLight : MonoBehaviour
{
    public void SendLightClickEvent()
    {
        EventBus<OnLightClicked>.Publish(new OnLightClicked());     
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
        SendLightClickEvent();
        //if (args.interactorObject.transform.CompareTag("LeftController")) VibrationManager.Instance.VibrateLeftController(0.2f, 0.1f);
        if (args.interactorObject.transform.CompareTag("RightController")) VibrationManager.Instance.VibrateRightController(0.2f, 0.1f);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
    }
}
