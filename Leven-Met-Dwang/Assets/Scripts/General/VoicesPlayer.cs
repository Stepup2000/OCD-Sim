using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicesPlayer : MonoBehaviour
{
    [SerializeField] private string[] _bookSounds;    // Sound clips related to the "Book" quest
    [SerializeField] private string[] _lightSounds;   // Sound clips related to the "Lights" quest
    [SerializeField] private string[] _washSounds;    // Sound clips related to the "Wash" quest

    [SerializeField] private Dictionary<string, string[]> _subjectSounds = new Dictionary<string, string[]>();  // Dictionary to store sounds related to each subject
    [SerializeField] private int _soundCooldown = 1;  // Cooldown duration between playing sounds

    private string lastSubject = "";   // Stores the last subject triggered by the quest

    private void OnEnable()
    {
        EventBus<OnQuestStart>.Subscribe(OnQuestStarted);  // Subscribe to the OnQuestStart event
        InvokeRepeating("PlayClockSound", 9, 9);  // Invoke playing the clock sound every 9 seconds
    }

    public void OnDisable()
    {
        EventBus<OnQuestStart>.UnSubscribe(OnQuestStarted);  // Unsubscribe from the OnQuestStart event
    }

    private void Start()
    {
        // Assign sound arrays to each subject in the dictionary
        _subjectSounds.Add("Book", _bookSounds);
        _subjectSounds.Add("Lights", _lightSounds);
        _subjectSounds.Add("Wash", _washSounds);

        // Invoke playing a random sound after a certain cooldown duration
        InvokeRepeating("PlayRandomSound", _soundCooldown, _soundCooldown);
    }

    private void OnQuestStarted(OnQuestStart questStartEvent)
    {
        lastSubject = questStartEvent.value;  // Update the last subject triggered by the quest
    }

    private void PlayRandomSound()
    {
        // Check if the last triggered subject exists in the dictionary
        if (_subjectSounds.ContainsKey(lastSubject))
        {
            string[] selectedSounds = _subjectSounds[lastSubject];  // Get the sounds related to the last subject
            AudioManager.Instance.PlayRandomSound(selectedSounds, 0.95f, 1.05f);  // Play a random sound from the selected sounds
        }
    }

    private void PlayClockSound()
    {
        AudioManager.Instance.PlayLongSound("Clock");  // Play the clock sound
    }
}
