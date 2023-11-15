using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BookQuest : Quest
{
    // Array to hold references to all BookPlaceChecker instances in the game
    private BookPlaceChecker[] _bookCheckers;
    private bool _questCompleted = false;

    private void OnEnable()
    {
        ChangeUI(); // Call the method to change UI related to the quest
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Plaats de boeken op de juiste plek")); // Publish UI change event
    }

    override public void ActivateQuest()
    {
        // Find all instances of BookPlaceChecker in the scene
        _bookCheckers = FindObjectsOfType<BookPlaceChecker>();
        InvokeRepeating("CheckQuestCompletion", 1f, 1f); // Invoke a method repeatedly after a delay
        Debug.Log("Quest Started");
    }

    override public void DeactivateQuest()
    {
        CancelInvoke("CheckQuestCompletion");
        Debug.Log("Quest Ended");
        Destroy(gameObject);
    }

    override public void CheckQuestCompletion()
    {
        bool allCheckersFilled = true;

        // Loop through all book checkers and check if they are filled
        foreach (var checker in _bookCheckers)
        {
            if (!checker.bookIsPlaced)
            {
                allCheckersFilled = false;
                break; // If one checker is not filled, no need to check the rest
            }
        }

        // Debug.Log("Booksplaced" + allCheckersFilled);

        // Determine if all checkers are filled and the quest is not completed
        if (allCheckersFilled && _questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete()); // Publish quest completion event
            _questCompleted = true; // Set quest completion flag to true
        }
    }
}
