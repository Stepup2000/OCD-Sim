using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndQuest : Quest
{
    private bool _questCompleted = false;

    private void Start()
    {
        Invoke("ChangeUI", 1f);
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Ga naar buiten"));
    }

    public override void ActivateQuest()
    {
        Debug.Log("Quest Started");
    }

    public override void DeactivateQuest()
    {
        Debug.Log("Quest Ended");
        Destroy(gameObject);
    }

    override public void CheckQuestCompletion()
    {
    }

    private void CompleteQuest(EnteredRoom enteredRoom)
    {
        if (_questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true;
        }        
    }
}
