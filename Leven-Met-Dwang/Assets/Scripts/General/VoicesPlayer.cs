using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicesPlayer : MonoBehaviour
{
    [SerializeField] private string[] _bookSounds;
    [SerializeField] private string[] _lightSounds;
    [SerializeField] private string[] _washSounds;

    [SerializeField] private Dictionary<string, string[]> _subjectSounds = new Dictionary<string, string[]>();
    [SerializeField] private int _soundCooldown = 1;

    private string lastSubject = "";

    private void OnEnable()
    {
        EventBus<OnQuestStart>.Subscribe(OnQuestStarted);
        InvokeRepeating("PlayClockSound", 9, 9);
    }

    public void OnDisable()
    {
        EventBus<OnQuestStart>.UnSubscribe(OnQuestStarted);
    }

    private void Start()
    {
        _subjectSounds.Add("Book", _bookSounds);
        _subjectSounds.Add("Lights", _lightSounds);
        _subjectSounds.Add("Wash", _washSounds);

        InvokeRepeating("PlayRandomSound", _soundCooldown, _soundCooldown);
    }

    private void OnQuestStarted(OnQuestStart questStartEvent)
    {
        lastSubject = questStartEvent.value;
    }

    private void PlayRandomSound()
    {
        if (_subjectSounds.ContainsKey(lastSubject))
        {
            string[] selectedSounds = _subjectSounds[lastSubject];
            AudioManager.Instance.PlayRandomSound(selectedSounds, 0.95f, 1.05f);
        }
    }

    private void PlayClockSound()
    {
        AudioManager.Instance.PlayLongSound("Clock");
    }
}

