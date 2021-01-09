namespace TheDark
{
    public interface IGameEvent
    {
        void Raise();
        void AddListener(IGameEventListener listener);
        void RemoveListener(IGameEventListener listener);
    }
}