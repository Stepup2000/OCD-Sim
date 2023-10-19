using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorForQuest : MonoBehaviour
{
    [SerializeField] Material _newMaterial;
    [SerializeField] string _questName;

    Material _oldMaterial;
    Renderer _myRenderer;

    private void OnEnable()
    {
        EventBus<OnQuestStart>.Subscribe(CheckColorChange);
        _myRenderer = GetComponent<Renderer>();
        if (_myRenderer != null) _oldMaterial = _myRenderer.material;
    }


    public void OnDisable()
    {
        EventBus<OnQuestStart>.UnSubscribe(CheckColorChange);
    }

    private bool CheckForNullPointers()
    {
        bool trueOrFalse = false;
        if (_oldMaterial == null || _newMaterial == null || _myRenderer == null) trueOrFalse = true;
        return trueOrFalse;
    }

    private void CheckColorChange(OnQuestStart onQuestStart)
    {
        if (CheckForNullPointers() == true) return;

        if (onQuestStart.value == _questName) RevertColorChanges();
        else _myRenderer.material = _newMaterial;
    }

    public void RevertColorChanges()
    {
        _myRenderer.material = _oldMaterial;
    }
}
