using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorForQuest : MonoBehaviour
{
    [SerializeField] Material _newMaterial; // The new material to change to
    [SerializeField] string _questName; // Name of the quest to trigger color change

    Material _oldMaterial; // Original material before color change
    Renderer _myRenderer;

    private void OnEnable()
    {
        // Subscribe to the OnQuestStart event
        EventBus<OnQuestStart>.Subscribe(CheckColorChange);

        _myRenderer = GetComponentInChildren<Renderer>();

        // Store the current material as the old material if a renderer is found
        if (_myRenderer != null)
            _oldMaterial = _myRenderer.material;
    }

    public void OnDisable()
    {
        // Unsubscribe from the OnQuestStart event
        EventBus<OnQuestStart>.UnSubscribe(CheckColorChange);
    }

    // Check for null references among critical variables
    private bool CheckForNullPointers()
    {
        bool trueOrFalse = false;
        if (_oldMaterial == null || _newMaterial == null || _myRenderer == null)
            trueOrFalse = true;
        return trueOrFalse;
    }

    // Check for a quest start event and change color if conditions are met
    private void CheckColorChange(OnQuestStart onQuestStart)
    {
        // If any critical reference is null, exit the method
        if (CheckForNullPointers() == true) return;

        // Check if the incoming quest name matches the specified quest name
        if (onQuestStart.value == _questName)
            _myRenderer.material = _newMaterial; // Change the renderer's material to the new material
        else
            RevertColorChanges();
    }

    public void RevertColorChanges()
    {
        // Change the renderer's material back to the original material
        _myRenderer.material = _oldMaterial;
    }
}
