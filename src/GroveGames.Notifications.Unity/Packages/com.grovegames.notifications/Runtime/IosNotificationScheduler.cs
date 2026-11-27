#if UNITY_IOS
using Unity.Notifications.iOS;

namespace GroveGames.Notifications.Unity
{
    public sealed class IosNotificationScheduler : INotificationScheduler
    {
        private const double MinimumRepeatSeconds = 60d;
        private const double ImmediateSeconds = 1d;

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
                if (repeatInterval.TotalSeconds < MinimumRepeatSeconds)
                {
                    UnityEngine.Debug.LogWarning($"iOS repeats a notification at least every {MinimumRepeatSeconds} seconds, so '{request.Id}' repeats every minute instead of every {repeatInterval.TotalSeconds} seconds.");
                    repeatInterval = System.TimeSpan.FromSeconds(MinimumRepeatSeconds);
                }

                notification.Trigger = new iOSNotificationTimeIntervalTrigger
                {
                    TimeInterval = repeatInterval,
                    Repeats = true,
                };
            }
            else if ((request.FireTime.Kind == System.DateTimeKind.Utc ? request.FireTime : request.FireTime.ToUniversalTime()) <= System.DateTime.UtcNow)
            {
                notification.Trigger = new iOSNotificationTimeIntervalTrigger
                {
                    TimeInterval = System.TimeSpan.FromSeconds(ImmediateSeconds),
                    Repeats = false,
                };
            }
            else
            {
                var fireTime = request.FireTime.Kind == System.DateTimeKind.Utc ? request.FireTime.ToLocalTime() : request.FireTime;

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
