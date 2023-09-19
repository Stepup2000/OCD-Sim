using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightswitchQuest : MonoBehaviour
{
    [SerializeField] private int neededClicks = 8;
    [SerializeField] private TMP_Text _UItext;

    public void ReduceClickCounter()
    {
        if (neededClicks > 0)
        {
            neededClicks--;
            if (_UItext != null) _UItext.text = "Clicks needed: " + neededClicks;
        }
    }
}
