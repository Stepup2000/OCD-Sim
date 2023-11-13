using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneAfterCooldown : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _cooldown = 0.1f;

    private void Start()
    {
        Invoke("LoadLevel", _cooldown);   
    }

    public void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(_sceneName);
    }
}
