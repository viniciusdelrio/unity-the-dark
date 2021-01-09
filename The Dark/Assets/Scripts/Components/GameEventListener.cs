using UnityEngine;
using UnityEngine.Events;

namespace TheDark
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEvent @event;
        [SerializeField] private UnityEvent response;

        private void OnEnable() =>
            @event.AddListener(this);

        private void OnDisable() =>
            @event.RemoveListener(this);

        public void OnEventRaised() =>
            response.Invoke();
    }
}
