using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightswitchQuest : Quest
{
    [SerializeField] private int neededClicks = 8;
    private TMP_Text _UItext;
    private bool _questCompleted = false;

    private void OnEnable()
    {
        GameObject missionText = GameObject.Find("MissionText");
        if (missionText != null) _UItext = missionText.GetComponent<TMP_Text>();
        EventBus<OnLightClicked>.Subscribe(ReduceClickCounter);
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
            UpdateText();
            CheckQuestCompletion();
        }
    }

    public void UpdateText()
    {
        if (_UItext != null) _UItext.text = "Click the light " + neededClicks + " Times";
        Debug.Log("TextUpdated");
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
