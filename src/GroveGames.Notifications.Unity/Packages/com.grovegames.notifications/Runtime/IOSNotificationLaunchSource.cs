#if UNITY_IOS
using Unity.Notifications.iOS;

namespace GroveGames.Notifications.Unity
{
    public sealed class IOSNotificationLaunchSource : INotificationLaunchSource
    {
        private bool _consumed;

        public string? ConsumeLaunchPayload()
        {
            if (_consumed)
            {
                return null;
            }

            _consumed = true;

            var notification = iOSNotificationCenter.QueryLastRespondedNotification().Notification;
            return notification?.Data;
        }
    }
}
#endif
