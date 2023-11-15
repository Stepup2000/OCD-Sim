using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    // This method is called when another Collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Publishes an EnteredRoom event when a Collider enters this trigger area
        // This event signifies that the player or another game object has entered the room
        // It provides a signal for systems or scripts interested in room entry
        EventBus<EnteredRoom>.Publish(new EnteredRoom());
    }
}
