using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLight : MonoBehaviour
{
    public void ClickTheLight()
    {
        EventBus<OnLightClicked>.Publish(new OnLightClicked());
    }
}
