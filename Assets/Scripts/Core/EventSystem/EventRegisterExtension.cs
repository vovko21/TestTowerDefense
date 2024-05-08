public static class EventRegisterExtension
{
    public static void StartListeningEvent<EventType>(this IEventListener<EventType> caller) where EventType : struct
    {
        EventManager.AddListener<EventType>(caller);
    }

    public static void StopListeningEvent<EventType>(this IEventListener<EventType> caller) where EventType : struct
    {
        EventManager.RemoveListener<EventType>(caller);
    }
}