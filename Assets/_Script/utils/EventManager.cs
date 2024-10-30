using System;
using System.Collections.Generic;

public class EventManager : MonoSingleton<EventManager>
{
    private Dictionary<string, EventHandler> _dictEventhandler = new Dictionary<string, EventHandler>();

    public void AddListener(string eventName, EventHandler handler){
        if (_dictEventhandler.ContainsKey(eventName)) {
            _dictEventhandler[eventName] += handler;
        } else {
            _dictEventhandler.Add(eventName, handler);
        }
    }

    public void RemoveListener(string eventName, EventHandler handler){
        if (_dictEventhandler.ContainsKey(eventName)) {
            _dictEventhandler[eventName] -= handler;
        }
    }

    public void Clear() {
        _dictEventhandler.Clear();
    }

    public void RemoveAllListener(string eventName){
        if (_dictEventhandler.ContainsKey(eventName)) {
            _dictEventhandler.Remove(eventName);
        }
    }

    // 无参触发
    public void TriggerEvent(string eventName, object invoker) {
        if (_dictEventhandler.ContainsKey(eventName)) {
            _dictEventhandler[eventName]?.Invoke(invoker, EventArgs.Empty);
        }
    }

    // 有参触发
    public void TriggerEvent(string eventName, object invoker, EventArgs args) {
        if (_dictEventhandler.ContainsKey(eventName)) {
            _dictEventhandler[eventName]?.Invoke(invoker, args);
        }
    }
}
