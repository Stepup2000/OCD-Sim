using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text subtitleText; // Reference to the TextMeshPro text component for subtitles
    [SerializeField] private SubtitleData[] subtitles; // Array holding subtitle data
    private int currentSubtitleIndex = 0; // Index to track the current subtitle being displayed

    IEnumerator Start()
    {
        // Loop through the subtitles array
        while (currentSubtitleIndex < subtitles.Length)
        {
            // Display the current subtitle text
            subtitleText.text = subtitles[currentSubtitleIndex].text;
            // Wait for the duration specified in the subtitle data
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            // Move to the next subtitle
            currentSubtitleIndex++;
        }

        // Clear the subtitle text when all subtitles have been displayed
        subtitleText.text = "";
    }
}
