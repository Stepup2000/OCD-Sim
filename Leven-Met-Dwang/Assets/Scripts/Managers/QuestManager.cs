using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Quest[] _questArray;
    Quest _currentQuest;
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
        if (_currentQuestIndex < _questArray.Length)
        {
            _currentQuest = Instantiate<Quest>(_questArray[_currentQuestIndex], transform.position, Quaternion.identity);
            _currentQuest.ActivateQuest();
            _currentQuest.transform.SetParent(this.transform);
        }
        else Debug.Log("No quest available");        
    }

    private void FinishCurrentQuest(OnQuestComplete questCompleteEvent)
    {
        _currentQuest.DeactivateQuest();
        _currentQuestIndex++;
        StartNewQuest();
    }
}
