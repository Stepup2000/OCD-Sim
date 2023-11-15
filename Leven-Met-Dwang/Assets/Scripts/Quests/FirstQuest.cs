using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstQuest : Quest
{
    private bool _questCompleted = false; // Flag to track if the quest is completed

    private void OnEnable()
    {
        EventBus<EnteredRoom>.Subscribe(CompleteQuest); // Subscribe to the EnteredRoom event
        Invoke("ChangeUI", 1f); // Invoke the ChangeUI method after a 1-second delay
    }

    public void OnDisable()
    {
        EventBus<EnteredRoom>.UnSubscribe(CompleteQuest); // Unsubscribe from the EnteredRoom event
    }

    // Method to change UI related to the quest
    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Loop naar de woonkamer")); // Publish UI change event
    }

    // Method to activate the quest
    public override void ActivateQuest()
    {
    }

    // Method to deactivate the quest
    public override void DeactivateQuest()
    {
        Destroy(gameObject); // Destroy the GameObject this script is attached to
    }

    // Method to check if the quest is completed
    override public void CheckQuestCompletion()
    {
        // This method is empty as the completion condition is handled by another method
    }

    // Method to handle completing the quest based on room entry
    private void CompleteQuest(EnteredRoom enteredRoom)
    {
        // Check if the quest is not yet completed
        if (_questCompleted == false)
        {
            // Publish the event signaling quest completion
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true; // Set the quest completion flag to true
        }
    }
}
