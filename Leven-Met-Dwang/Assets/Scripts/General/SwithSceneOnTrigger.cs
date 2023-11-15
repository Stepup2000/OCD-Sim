using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private string _sceneName; // The name of the scene to switch to

    // This method is called when another collider enters this GameObject's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // If the collider belongs to the player, load the specified scene using the LevelManager
            LevelManager.Instance.LoadLevel(_sceneName);
        }
    }
}
