using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BookQuest : Quest
{
    // Array to hold references to all BookPlaceChecker instances in the game
    private BookPlaceChecker[] _bookCheckers;
    private bool _questCompleted = false;
    private TMP_Text _UItext;

    private void OnEnable()
    {
        SetUI();
        ChangeUI();
    }

    private void SetUI()
    {
        GameObject missionText = GameObject.Find("MissionText");
        if (missionText != null) _UItext = missionText.GetComponent<TMP_Text>();
    }

    override public void ChangeUI()
    {
        if (_UItext != null) _UItext.text = "Place the books in the right place";
        else
        {
            SetUI();
            Invoke("ChangeUI", 1f);
        }
    }

    override public void ActivateQuest()
    {
        // Find all instances of BookPlaceChecker in the scene
        _bookCheckers = FindObjectsOfType<BookPlaceChecker>();
        InvokeRepeating("CheckQuestCompletion", 1f, 1f);
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

        //Debug.Log("Booksplaced" + allCheckersFilled);

        // Now you can use the 'allCheckersFilled' boolean to determine if all checkers are filled
        if (allCheckersFilled && _questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true;
        }
    }
}