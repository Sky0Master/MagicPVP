using System;

public static class EventTriggerExt
{
    public static void TriggerEvent(this object invoker, string eventName) {
        EventManager.Instance.TriggerEvent(eventName, invoker);
    }

    public static void TriggerEvent(this object invoker, string eventName, EventArgs args) {
        EventManager.Instance.TriggerEvent(eventName, invoker, args);
    }
}
