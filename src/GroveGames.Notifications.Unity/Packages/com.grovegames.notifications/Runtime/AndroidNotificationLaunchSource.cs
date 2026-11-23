#if UNITY_ANDROID
using Unity.Notifications.Android;

namespace GroveGames.Notifications.Unity
{
    public sealed class AndroidNotificationLaunchSource : INotificationLaunchSource
    {
        private bool _consumed;

        public string? ConsumeLaunchPayload()
        {
            if (_consumed)
            {
                return null;
            }

            _consumed = true;

            var intentData = AndroidNotificationCenter.GetLastNotificationIntent();
            return intentData?.Notification.IntentData;
        }
    }
}
#endif
