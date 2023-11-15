using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private int _doorSpawnDuration = 15; // Duration before spawning the door
    [SerializeField] private int _toggleAmount = 12; // Number of toggles for the alarm clock
    [SerializeField] private int _alarmDelay = 4; // Delay before the alarm clock starts
    [SerializeField] private GameObject _door; // Reference to the door GameObject
    [SerializeField] private Canvas _canvas; // Reference to the Canvas GameObject for UI

    private int toggleCount = 0; // Counter to keep track of toggles

    private void Start()
    {
        _door.gameObject.SetActive(false); // Deactivate the door initially
        if (_canvas != null) _canvas.gameObject.SetActive(false); // Deactivate the Canvas if it exists
        AudioManager.Instance.PlaySound("Intro"); // Play the intro sound
        Invoke("SpawnDoor", _doorSpawnDuration); // Invoke the method to spawn the door after a duration
    }

    private void SpawnDoor()
    {
        if (_door != null)
        {
            _door.gameObject.SetActive(true);
            AudioManager.Instance.PlaySound("Explosion");
            Invoke("SpawnAlarmClock", _alarmDelay); // Invoke the method to spawn the alarm clock after a delay
        }
    }

    private void SpawnAlarmClock()
    {
        AudioManager.Instance.PlaySound("AlarmClock"); // Play the alarm clock sound
        InvokeRepeating("ToggleAlarmClock", 0.001f, 0.5f); // Invoke method to toggle the alarm clock at intervals
    }

    private void ToggleAlarmClock()
    {
        if (_canvas != null && toggleCount < _toggleAmount)
        {
            _canvas.gameObject.SetActive(!_canvas.gameObject.activeSelf); // Toggle the visibility of the Canvas
            toggleCount++;

            if (toggleCount >= _toggleAmount)
            {
                CancelInvoke("ToggleAlarmClock"); // Cancel the repeating toggle when the toggle amount is reached
            }
        }
    }
}
