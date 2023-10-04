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
}
