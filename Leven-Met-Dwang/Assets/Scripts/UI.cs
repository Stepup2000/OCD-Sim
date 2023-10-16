using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    private TMP_Text _UItext;

    private void OnEnable()
    {
        _UItext = GetComponentInChildren<TMP_Text>();
        EventBus<OnUIChange>.Subscribe(ChangeUI);
    }

    public void OnDisable()
    {
        EventBus<OnUIChange>.UnSubscribe(ChangeUI);
    }

    private void ChangeUI(OnUIChange onUIChange)
    {
        if (_UItext != null) _UItext.text = onUIChange.value;
        else Debug.Log("UIText not found");
    }
}
