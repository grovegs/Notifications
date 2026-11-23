#if UNITY_ANDROID
using Unity.Notifications.Android;

namespace GroveGames.Notifications.Unity
{
    public sealed class AndroidNotificationScheduler : INotificationScheduler
    {
        public void Schedule(in NotificationRequest request)
        {
            var notification = new AndroidNotification
            {
                Title = request.Title,
                Text = request.Body,
                FireTime = request.FireTime,
                IntentData = request.Payload,
                ShowTimestamp = true,
            };

            if (request.RepeatInterval is { } repeatInterval)
            {
                notification.RepeatInterval = repeatInterval;
            }

            AndroidNotificationCenter.SendNotificationWithExplicitID(
                notification,
                request.ChannelId,
                request.Id);
        }

        public void Cancel(NotificationId id)
        {
            AndroidNotificationCenter.CancelNotification(id);
        }

        public void CancelAll()
        {
            AndroidNotificationCenter.CancelAllNotifications();
        }
    }
}
#endif
