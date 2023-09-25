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
