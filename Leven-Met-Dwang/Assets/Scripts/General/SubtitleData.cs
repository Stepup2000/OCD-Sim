using UnityEngine;

[CreateAssetMenu(fileName = "NewSubtitle", menuName = "Subtitles/Subtitle")]
public class SubtitleData : ScriptableObject
{
    public float startTime;
    public float duration;
    public string text;
}