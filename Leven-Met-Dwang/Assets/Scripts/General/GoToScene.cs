using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(_sceneName);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
}
