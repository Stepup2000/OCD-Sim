using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicesPlayer : MonoBehaviour
{
    [SerializeField] private string[] _sounds;
    [SerializeField] private int _soundCooldown = 1;
    private void Start()
    {
        InvokeRepeating("PlayRandomSound", _soundCooldown, _soundCooldown);
    }    

    private void PlayRandomSound()
    {
        AudioManager.Instance.PlayRandomSound(_sounds, 0.95f, 1.05f);
    }
}
