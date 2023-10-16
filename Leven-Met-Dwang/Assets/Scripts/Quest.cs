using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public abstract void ChangeUI();
    public abstract void ActivateQuest();
    public abstract void DeactivateQuest();
    public abstract void CheckQuestCompletion();
}
