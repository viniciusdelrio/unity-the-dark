using System.Collections.Generic;
using UnityEngine;

namespace TheDark
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        private readonly List<IGameEventListener> listeners = new List<IGameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        public void AddListener(IGameEventListener listener) =>
            listeners.Add(listener);

        public void RemoveListener(IGameEventListener listener) =>
            listeners.Remove(listener);
    }
}
