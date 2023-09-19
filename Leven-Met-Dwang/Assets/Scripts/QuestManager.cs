using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Quest[] _questArray;
    private int _currentQuestIndex = 0;

    private void OnEnable()
    {
        // Subscribe to the SpawnEnemyEvent so we can queue enemies for spawning
        EventBus<OnQuestComplete>.Subscribe(FinishCurrentQuest);
    }

    private void OnDisable()
    {
        // Unsubscribe from the SpawnEnemyEvent and stop the spawning coroutine
        EventBus<OnQuestComplete>.UnSubscribe(FinishCurrentQuest);
    }

    private void Start()
    {
        if (_questArray.Length > 0 && _questArray[0] != null) StartNewQuest();
    }

    private void StartNewQuest()
    {
        _questArray[_currentQuestIndex].ActivateQuest();
        Debug.Log("Quest Started");
    }

    private void FinishCurrentQuest(OnQuestComplete questCompleteEvent)
    {
        _questArray[_currentQuestIndex].DeactivateQuest();
        _currentQuestIndex++;
        Debug.Log("Quest Ended");
    }
}
