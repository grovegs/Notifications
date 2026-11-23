#if UNITY_IOS
namespace GroveGames.Notifications.Unity
{
    public sealed class IOSNotificationChannelRegistry : INotificationChannelRegistry
    {
        public void Register(in NotificationChannel channel)
        {
        }
    }
}
#endif
