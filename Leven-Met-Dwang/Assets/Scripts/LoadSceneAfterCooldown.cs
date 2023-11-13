using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainMenuAfterCooldown : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _cooldown = 0.1f;

    private void Start()
    {
        Invoke("LoadLevel", _cooldown);   
    }

    private void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(_sceneName);
    }
}
