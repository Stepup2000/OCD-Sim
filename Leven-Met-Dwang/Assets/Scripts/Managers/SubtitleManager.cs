using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text subtitleText;
    [SerializeField] private SubtitleData[] subtitles;
    private int currentSubtitleIndex = 0;

    IEnumerator Start()
    {
        while (currentSubtitleIndex < subtitles.Length)
        {
            subtitleText.text = subtitles[currentSubtitleIndex].text;
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            currentSubtitleIndex++;
        }
        subtitleText.text = "";
    }
}
