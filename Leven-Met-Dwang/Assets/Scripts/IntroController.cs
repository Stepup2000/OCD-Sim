using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private int _doorSpawnDuration = 15;
    [SerializeField] private GameObject _door;
    [SerializeField] private Canvas _canvas;

    private int toggleCount = 0;

    private void Start()
    {
        _door.gameObject.SetActive(false);
        if (_canvas != null) _canvas.gameObject.SetActive(false);
        AudioManager.Instance.PlaySound("Intro");
        Invoke("SpawnDoor", _doorSpawnDuration);
    }

    private void SpawnDoor()
    {
        if (_door != null)
        {
            _door.gameObject.SetActive(true);
            AudioManager.Instance.PlaySound("Explosion");
            Invoke("SpawnAlarmClock", 5f);
        }
    }

    private void SpawnAlarmClock()
    {
        AudioManager.Instance.PlaySound("AlarmClock");
        InvokeRepeating("ToggleAlarmClock", 0.95f, 0.5f);
    }

    private void ToggleAlarmClock()
    {
        if (_canvas != null && toggleCount < 20)
        {
            _canvas.gameObject.SetActive(!_canvas.gameObject.activeSelf);
            toggleCount++;

            if (toggleCount >= 20)
            {
                CancelInvoke("ToggleAlarmClock");
            }
        }
    }
}
