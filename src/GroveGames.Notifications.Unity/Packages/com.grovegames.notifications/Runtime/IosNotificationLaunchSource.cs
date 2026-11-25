#if UNITY_IOS
using Unity.Notifications.iOS;

namespace GroveGames.Notifications.Unity
{
    public sealed class IosNotificationLaunchSource : INotificationLaunchSource
    {
        private QueryLastRespondedNotificationOp? _query;
        private bool _consumed;

        public string? ConsumeLaunchPayload()
        {
            if (_consumed)
            {
                return null;
            }

            _query ??= iOSNotificationCenter.QueryLastRespondedNotification();

            if (_query.State == QueryLastRespondedNotificationState.Pending)
            {
                return null;
            }

            _consumed = true;
            return _query.State == QueryLastRespondedNotificationState.HaveRespondedNotification ? _query.Notification?.Data : null;
        }
    }
}
#endif
