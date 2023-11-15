using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Quest[] _questArray; // Array holding various quests
    Quest _currentQuest; // Reference to the current active quest
    private int _currentQuestIndex = 0; // Index to track the current quest in the array

    private void OnEnable()
    {
        // Subscribe to the OnQuestComplete event to handle finishing quests
        EventBus<OnQuestComplete>.Subscribe(FinishCurrentQuest);
    }

    private void OnDisable()
    {
        // Unsubscribe from the OnQuestComplete event when disabled to avoid memory leaks
        EventBus<OnQuestComplete>.UnSubscribe(FinishCurrentQuest);
    }

    private void Start()
    {
        // Check if there are quests in the array and start the first one if available
        if (_questArray.Length > 0 && _questArray[0] != null) StartNewQuest();
    }

    private void StartNewQuest()
    {
        // Start a new quest if there are more quests in the array
        if (_currentQuestIndex < _questArray.Length)
        {
            // Instantiate the next quest, activate it, and set its parent to this manager object
            _currentQuest = Instantiate<Quest>(_questArray[_currentQuestIndex], transform.position, Quaternion.identity);
            _currentQuest.ActivateQuest();
            _currentQuest.transform.SetParent(this.transform);

            // Publish an event to notify about the start of the new quest
            EventBus<OnQuestStart>.Publish(new OnQuestStart(_currentQuest.questName));
        }
        else
        {
            // No more quests available, publish events for completion and UI change
            Debug.Log("No quest available");
            EventBus<OnAllQuestsComplete>.Publish(new OnAllQuestsComplete());
            EventBus<OnUIChange>.Publish(new OnUIChange("Ga door de voordeur"));
        }
    }

    private void FinishCurrentQuest(OnQuestComplete questCompleteEvent)
    {
        // Deactivate the current quest, increment quest index, and start the next quest
        _currentQuest.DeactivateQuest();
        _currentQuestIndex++;
        StartNewQuest();
    }
}
