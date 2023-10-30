using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstQuest : Quest
{
    private bool _questCompleted = false;

    private void OnEnable()
    {
        EventBus<EnteredRoom>.Subscribe(CompleteQuest);
        Invoke("ChangeUI", 1f);
    }


    public void OnDisable()
    {
        EventBus<EnteredRoom>.UnSubscribe(CompleteQuest);
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Walk into the room"));
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
