#if UNITY_EDITOR
namespace GroveGames.Notifications.Unity
{
    public sealed class EditorNotificationChannelRegistry : INotificationChannelRegistry
    {
        public void Register(in NotificationChannel channel)
        {
        }
    }
}
#endif
