using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightswitchQuest : Quest
{
    [SerializeField] private int neededClicks = 8;
    private bool _questCompleted = false;

    private void OnEnable()
    {
        EventBus<OnLightClicked>.Subscribe(ReduceClickCounter);
        ChangeUI();
    }
        

    public void OnDisable()
    {
        EventBus<OnLightClicked>.UnSubscribe(ReduceClickCounter);
    }

    public void ReduceClickCounter(OnLightClicked onLightClicked)
    {
        if (neededClicks > 0)
        {
            neededClicks--;
            ChangeUI();
            CheckQuestCompletion();
        }
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("Click the light " + neededClicks + " Times"));
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
        if (neededClicks < 1 && _questCompleted == false)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true;
        }
    }
}
