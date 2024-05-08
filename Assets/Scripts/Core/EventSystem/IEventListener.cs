public interface IEventListener<T> : IEventListenerBase
{
    void OnEvent(T eventParams);
}
