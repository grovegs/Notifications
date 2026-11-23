#if UNITY_IOS
using Unity.Notifications.iOS;

namespace GroveGames.Notifications.Unity
{
    public sealed class IosNotificationScheduler : INotificationScheduler
    {
        public void Schedule(in NotificationRequest request)
        {
            var notification = new iOSNotification
            {
                Identifier = request.Id,
                Title = request.Title,
                Body = request.Body,
                Data = request.Payload,
                CategoryIdentifier = request.ChannelId,
                ShowInForeground = false,
            };

            if (request.RepeatInterval is { } repeatInterval)
            {
                notification.Trigger = new iOSNotificationTimeIntervalTrigger
                {
                    TimeInterval = repeatInterval,
                    Repeats = true,
                };
            }
            else
            {
                var fireTime = request.FireTime;

                notification.Trigger = new iOSNotificationCalendarTrigger
                {
                    Year = fireTime.Year,
                    Month = fireTime.Month,
                    Day = fireTime.Day,
                    Hour = fireTime.Hour,
                    Minute = fireTime.Minute,
                    Second = fireTime.Second,
                    Repeats = false,
                };
            }

            iOSNotificationCenter.ScheduleNotification(notification);
        }

        public void Cancel(NotificationId id)
        {
            iOSNotificationCenter.RemoveScheduledNotification(id);
            iOSNotificationCenter.RemoveDeliveredNotification(id);
        }

        public void CancelAll()
        {
            iOSNotificationCenter.RemoveAllScheduledNotifications();
            iOSNotificationCenter.RemoveAllDeliveredNotifications();
        }
    }
}
#endif
