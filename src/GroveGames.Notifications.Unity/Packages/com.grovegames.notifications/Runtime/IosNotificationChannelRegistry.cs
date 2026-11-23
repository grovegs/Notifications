#if UNITY_IOS
namespace GroveGames.Notifications.Unity
{
    public sealed class IosNotificationChannelRegistry : INotificationChannelRegistry
    {
        public void Register(in NotificationChannel channel)
        {
        }
    }
}
#endif
