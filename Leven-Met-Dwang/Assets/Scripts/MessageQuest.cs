using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MessageQuest : Quest
{
    [SerializeField] private int _questDuration = 10;
    [SerializeField] string _canvasName;
    private Image _messageImage;
    private bool _questCompleted = false;

    private void OnEnable()
    {
        Invoke("CompleteQuestAfterDelay", 10f);
        Invoke("ChangeUI", 1f);
        GameObject foundObject = GameObject.Find(_canvasName);
        _messageImage = foundObject.GetComponent<Image>();
        ToggleMessageImage();
        AudioManager.Instance.PlaySound("Message");
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange(""));
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

    private void CompleteQuestAfterDelay()
    {
        StartCoroutine(CompleteQuestDelayed());
    }

    private IEnumerator CompleteQuestDelayed()
    {
        yield return new WaitForSeconds(_questDuration);
        CompleteQuest();
    }

    private void CompleteQuest()
    {
        if (!_questCompleted)
        {
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true;
            CheckQuestCompletion(); // Check for quest completion status
            ToggleMessageImage();
        }
    }

    private void ToggleMessageImage()
    {
        if (_messageImage != null)
        {
            _messageImage.enabled = !_messageImage.enabled;
            Debug.Log("Toggeled");
        }        
    }
}
