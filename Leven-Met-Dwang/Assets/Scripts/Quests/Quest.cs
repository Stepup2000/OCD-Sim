using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class defining the structure of a quest
public abstract class Quest : MonoBehaviour
{
    [SerializeField] public string questName;
    public abstract void ChangeUI();
    public abstract void ActivateQuest();
    public abstract void DeactivateQuest();
    public abstract void CheckQuestCompletion();
}
