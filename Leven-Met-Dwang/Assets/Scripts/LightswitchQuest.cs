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
        SetUI();
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

    private void SetUI()
    {
        GameObject missionText = GameObject.Find("MissionText");
        if (missionText != null) _UItext = missionText.GetComponent<TMP_Text>();
    }

    override public void ChangeUI()
    {
        if (_UItext != null) _UItext.text = "Click the light " + neededClicks + " Times";
        else
        {
            SetUI();
            Invoke("ChangeUI", 1f);
        }        
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
