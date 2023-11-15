using UnityEngine;

// Create a new asset menu entry to create SubtitleData ScriptableObjects
[CreateAssetMenu(fileName = "NewSubtitle", menuName = "Subtitles/Subtitle")]
public class SubtitleData : ScriptableObject
{
    // Time when the subtitle starts displaying
    public float startTime;

    // Duration for which the subtitle is displayed
    public float duration;

    // Text content of the subtitle
    public string text;
}
