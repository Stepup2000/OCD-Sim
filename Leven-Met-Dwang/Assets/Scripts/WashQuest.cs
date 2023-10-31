using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashQuest : Quest
{
    private bool _questCompleted = false;       

    private void OnEnable()
    {
        EventBus<WashHand>.Subscribe(CompleteQuest);
        Invoke("ChangeUI", 1f);
    }


    public void OnDisable()
    {
        EventBus<WashHand>.UnSubscribe(CompleteQuest);
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Was je handen"));
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

    private void CompleteQuest(WashHand washHand)
    {
        if (_questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true;
        }
    }
}
