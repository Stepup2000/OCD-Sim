using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroController : MonoBehaviour
{
    [SerializeField] private int _doorSpawnDuration = 15; // Duration before the door spawns
    [SerializeField] private GameObject _door; // Reference to the door GameObject

    private void Start()
    {
        _door.gameObject.SetActive(false); // Deactivates the door initially
        AudioManager.Instance.PlaySound("Outro"); // Plays the 'Outro' sound
        Invoke("SpawnDoor", _doorSpawnDuration); // Invokes the SpawnDoor method after a specified duration
    }

    // Activates the door after a certain duration
    private void SpawnDoor()
    {
        if (_door != null)
        {
            _door.gameObject.SetActive(true); // Activates the door
            AudioManager.Instance.PlaySound("Explosion"); // Plays the 'Explosion' sound
        }
    }
}
