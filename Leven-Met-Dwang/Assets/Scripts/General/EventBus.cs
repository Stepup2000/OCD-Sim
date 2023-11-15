using System;
using UnityEngine;
using System.Collections.Generic;

public class EventBus<T> where T : Event
{
    public static event Action<T> OnEvent;

    public static void Subscribe(Action<T> handler)
    {
        OnEvent += handler;
    }

    public static void UnSubscribe(Action<T> handler)
    {
        OnEvent -= handler;
    }

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}

// Event indicating the start of a quest with a provided value
public class OnQuestStart : Event
{
    public readonly string value;
    public OnQuestStart(string newValue)
    {
        value = newValue;
    }
}

// Event indicating the completion of a quest
public class OnQuestComplete : Event
{
    public OnQuestComplete()
    {
    }
}

// Event triggered when a light is clicked
public class OnLightClicked : Event
{
    public OnLightClicked()
    {
    }
}

// Event indicating the completion of all quests
public class OnAllQuestsComplete : Event
{
    public OnAllQuestsComplete()
    {
    }
}

// Event for UI change with a provided value
public class OnUIChange : Event
{
    public readonly string value;
    public OnUIChange(string newValue)
    {
        value = newValue;
    }
}

// Event triggered when entering a room
public class EnteredRoom : Event
{
    public EnteredRoom()
    {
    }
}

// Event for hand washing action
public class WashHand : Event
{
    public WashHand()
    {
    }
}