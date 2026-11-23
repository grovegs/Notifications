#if UNITY_ANDROID
using Unity.Notifications.Android;

namespace GroveGames.Notifications.Unity
{
    public sealed class AndroidNotificationChannelRegistry : INotificationChannelRegistry
    {
        public void Register(in NotificationChannel channel)
        {
            var importance = channel.Importance switch
            {
                NotificationImportance.Low => Importance.Low,
                NotificationImportance.High => Importance.High,
                _ => Importance.Default,
            };

            AndroidNotificationCenter.RegisterNotificationChannel(new AndroidNotificationChannel(
                channel.Id,
                channel.Name,
                channel.Description,
                importance));
        }
    }
}
#endif
