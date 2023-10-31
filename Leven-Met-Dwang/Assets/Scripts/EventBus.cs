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

public class OnQuestStart : Event
{
    public readonly string value;
    public OnQuestStart(string newValue)
    {
        value = newValue;
    }
}

public class OnQuestComplete : Event
{
    public OnQuestComplete()
    {
    }
}

public class OnLightClicked : Event
{
    public OnLightClicked()
    {
    }
}

public class OnAllQuestsComplete : Event
{
    public OnAllQuestsComplete()
    {
    }
}

public class OnUIChange : Event
{
    public readonly string value;
    public OnUIChange(string newValue)
    {
        value = newValue;
    }
}

public class EnteredRoom : Event
{
    public EnteredRoom()
    {
    }
}

public class WashHand : Event
{
    public WashHand()
    {
    }
}