using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashQuest : Quest
{
    private bool _questCompleted = false; // Flag to track quest completion

    private void OnEnable()
    {
        // Subscribe to the WashHand event to complete the quest
        EventBus<WashHand>.Subscribe(CompleteQuest);
        // Invoke the ChangeUI method after a 1-second delay
        Invoke("ChangeUI", 1f);
    }

    public void OnDisable()
    {
        // Unsubscribe from the WashHand event
        EventBus<WashHand>.UnSubscribe(CompleteQuest);
    }

    override public void ChangeUI()
    {
        // Publish an event to change the UI to instruct the player
        EventBus<OnUIChange>.Publish(new OnUIChange("Was je handen voor 3 seconden"));
    }

    public override void ActivateQuest()
    {
    }

    public override void DeactivateQuest()
    {
        Destroy(gameObject);
    }

    // Method to check the completion status of the quest
    override public void CheckQuestCompletion()
    {
    }

    private void CompleteQuest(WashHand washHand)
    {
        // Check if the quest has not been completed yet
        if (_questCompleted == false)
        {
            // Publish an event signaling the completion of the quest
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true; // Set the quest completion flag to true
        }
    }
}
