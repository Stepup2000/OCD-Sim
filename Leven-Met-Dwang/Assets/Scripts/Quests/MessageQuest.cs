using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MessageQuest : Quest
{
    [SerializeField] private int _questDuration = 10; // Duration of the quest in seconds
    [SerializeField] string _canvasName; // Name of the canvas where the image resides
    private Image _messageImage = null; // Reference to the Image component
    private bool _questCompleted = false; // Flag to track if the quest is completed

    private void OnEnable()
    {
        // Invoke method to complete the quest after the specified duration
        Invoke("CompleteQuest", _questDuration);

        // Invoke method to change the UI after a 1-second delay
        Invoke("ChangeUI", 1f);

        // Find the GameObject by name and get the Image component
        GameObject foundObject = GameObject.Find(_canvasName);
        _messageImage = foundObject.GetComponent<Image>();

        // Toggle the message image visibility
        ToggleMessageImage();

        // Play sound effect when the message starts
        AudioManager.Instance.PlaySound("Message");
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    // Method to change the UI (in this case, it clears the UI message)
    override public void ChangeUI()
    {
        EventBus<OnUIChange>.Publish(new OnUIChange("")); // Publish an empty UI change event
    }

    public override void ActivateQuest()
    {
    }

    public override void DeactivateQuest()
    {
        Destroy(gameObject);
    }

    override public void CheckQuestCompletion()
    {
        // This method is empty as the completion condition is handled in CompleteQuest method
    }

    // Method to complete the quest and toggle the message image visibility
    private void CompleteQuest()
    {
        // Check if the quest is not yet completed
        if (!_questCompleted)
        {
            // Publish the event signaling quest completion
            EventBus<OnQuestComplete>.Publish(new OnQuestComplete());
            _questCompleted = true; // Set the quest completion flag to true
            CheckQuestCompletion(); // Check if the quest is completed
            ToggleMessageImage(); // Toggle the visibility of the message image
        }
    }

    // Method to toggle the visibility of the message image
    private void ToggleMessageImage()
    {
        // Check if the message image reference is not null
        if (_messageImage != null)
        {
            // Toggle the visibility of the message image
            _messageImage.enabled = !_messageImage.enabled;

            // Play notification sound if the image is enabled
            if (_messageImage.enabled == true)
            {
                AudioManager.Instance.PlaySound("NotificationSound");
            }
        }
    }
}
