using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroController : MonoBehaviour
{
    [SerializeField] private int _doorSpawnDuration = 15;
    [SerializeField] private GameObject _door;

    private void Start()
    {
        _door.gameObject.SetActive(false);
        AudioManager.Instance.PlaySound("Outro");
        Invoke("SpawnDoor", _doorSpawnDuration);
    }

    private void SpawnDoor()
    {
        if (_door != null)
        {
            _door.gameObject.SetActive(true);
            AudioManager.Instance.PlaySound("Explosion");
        }
    }
}
