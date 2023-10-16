using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnQuestCompletion : MonoBehaviour
{
    private BoxCollider _collider;

    private void OnEnable()
    {
        EventBus<OnAllQuestsComplete>.Subscribe(RemoveCollider);
        TryGetComponent<BoxCollider>(out _collider);
    }

    public void OnDisable()
    {
        EventBus<OnAllQuestsComplete>.UnSubscribe(RemoveCollider);
    }

    private void RemoveCollider(OnAllQuestsComplete onAllQuestsComplete)
    {
        if (_collider != null) _collider.enabled = false;
    }
}
