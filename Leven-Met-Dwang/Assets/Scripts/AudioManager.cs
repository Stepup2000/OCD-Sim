using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires a AudioSource component to work
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _shortAudioSource;
    [SerializeField] private AudioSource _LongAudioSource;
    public static AudioManager current;

    //Fires after object has been initialized
    private void Awake()
    {
        current = this;
    }

    //Plays given soundfile
    public void PlaySound(string soundName, float lowerPitch = 1.0f, float higherPitch = 1.0f)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(soundName);
        if (audioClip == null)
        {
            Debug.Log("Failed");
            return;
        }

        //Adjusts pitch randomly
        float pitchModifier = Random.Range(lowerPitch, higherPitch);

        _shortAudioSource.pitch = pitchModifier;
        _shortAudioSource.PlayOneShot(audioClip, 1);
    }

    //Play a sound that can play over a longer time (only one at a time)
    public void PlayLongSound(string soundName)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(soundName);
        if (audioClip == null) return;

        _LongAudioSource.clip = audioClip;
        _LongAudioSource.Play();
    }

    //Plays one random sound out of a given array
    public void PlayRandomSound(string[] soundNames)
    {
        int number = Random.Range(0, soundNames.Length);
        PlaySound(soundNames[number]);
    }
}