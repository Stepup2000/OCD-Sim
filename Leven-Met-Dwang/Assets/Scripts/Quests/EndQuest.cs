using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndQuest : Quest
{
    private bool _questCompleted = false; // Flag to track if the quest is completed

    private void Start()
    {
        Invoke("ChangeUI", 1f); // Invoke the ChangeUI method after 1 second delay
    }

    // Method to change UI related to the quest
    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Ga naar buiten")); // Publish UI change event
    }

    public override void ActivateQuest()
    {
        Debug.Log("Quest Started");
    }

    public override void DeactivateQuest()
    {
        Debug.Log("Quest Ended"); // Log a message indicating the quest has ended
        Destroy(gameObject); // Destroy the GameObject this script is attached to
    }

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
