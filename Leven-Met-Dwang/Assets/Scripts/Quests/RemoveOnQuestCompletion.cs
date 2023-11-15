using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnQuestCompletion : MonoBehaviour
{
    private BoxCollider _collider; // Reference to the BoxCollider component attached to the GameObject

    private void OnEnable()
    {
        EventBus<OnAllQuestsComplete>.Subscribe(RemoveCollider); // Subscribe to the OnAllQuestsComplete event
        TryGetComponent<BoxCollider>(out _collider); // Attempt to get the BoxCollider component
    }

    public void OnDisable()
    {
        EventBus<OnAllQuestsComplete>.UnSubscribe(RemoveCollider); // Unsubscribe from the OnAllQuestsComplete event
    }

    // Method to remove or disable the collider when all quests are completed
    private void RemoveCollider(OnAllQuestsComplete onAllQuestsComplete)
    {
        if (_collider != null)
        {
            _collider.enabled = false; // Disable the collider if it exists
        }
    }
}
