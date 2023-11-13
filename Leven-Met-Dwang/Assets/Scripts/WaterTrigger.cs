using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] private float _triggerDuration = 3.0f; // Time to trigger the event
    private bool _isInsideTrigger = false;
    private float _timeInsideTrigger = 0f;

    private void OnTriggerEnter(Collider other)
    {
        _isInsideTrigger = true; // Set the flag to indicate the trigger area is entered.
    }

    private void OnTriggerExit(Collider other)
    {
        _isInsideTrigger = false; // Set the flag to indicate the trigger area is exited.
    }

    private void Update()
    {
        if (_isInsideTrigger)
        {
            _timeInsideTrigger += Time.deltaTime;

            // Check if the time inside the trigger is more than the specified duration.
            if (_timeInsideTrigger >= _triggerDuration)
            {
                // Trigger the event and reset the timer.
                EventBus<WashHand>.Publish(new WashHand());
                _timeInsideTrigger = 0f;
            }
        }
    }
}
