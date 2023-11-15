using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightswitchQuest : Quest
{
    [SerializeField] private int neededClicks = 8; // Number of clicks required to complete the quest
    private bool _questCompleted = false; // Flag to track if the quest is completed

    private void OnEnable()
    {
        EventBus<OnLightClicked>.Subscribe(ReduceClickCounter); // Subscribe to the OnLightClicked event
    }


    public void OnDisable()
    {
        EventBus<OnLightClicked>.UnSubscribe(ReduceClickCounter); // Unsubscribe from the OnLightClicked event
    }

    // Method to reduce the click counter and trigger UI update and quest completion check
    public void ReduceClickCounter(OnLightClicked onLightClicked)
    {
        // Reduce the click counter if neededClicks is greater than 0
        if (neededClicks > 0)
        {
            neededClicks--;
            ChangeUI();
            CheckQuestCompletion();
        }
    }

    // Method to update the UI with the remaining clicks needed
    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Klik " + neededClicks + " keer op de lichtknop")); // Publish UI change event
    }

    // Method to activate the quest and update UI
    public override void ActivateQuest()
    {
        ChangeUI();
    }

    // Method to deactivate the quest
    public override void DeactivateQuest()
    {
        Destroy(gameObject); // Destroy the GameObject this script is attached to
    }

    // Method to check if the quest is completed
    override public void CheckQuestCompletion()
    {
        // Check if the required clicks have been reached and the quest is not yet completed
        if (neededClicks < 1 && _questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete()); // Publish the event signaling quest completion
            _questCompleted = true; // Set the quest completion flag to true
        }
    }
}
