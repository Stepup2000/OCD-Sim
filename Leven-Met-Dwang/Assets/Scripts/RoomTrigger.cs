using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventBus<EnteredRoom>.Publish(new EnteredRoom());
    }
}
