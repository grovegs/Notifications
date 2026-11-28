using System;
using GroveGames.DeveloperTools;

namespace GroveGames.Notifications.Unity.DeveloperTools
{
    public sealed class NotificationsDeveloperOptions : IDeveloperOptions
    {
        private const string ChannelId = "developer-tools";
        private const string NotificationId = "developer-tools-test";

        private readonly INotificationScheduler _scheduler;
        private readonly INotificationPermission _permission;
        private readonly INotificationChannelRegistry _channels;
        private bool _isChannelRegistered;

        [DeveloperOption(Header = "Test", Min = 1f, Max = 300f, Tooltip = "Seconds until the test notification fires. Leave the app before it fires.")] private int _delay;

        public string Category => "Notifications";

        public NotificationsDeveloperOptions(INotificationScheduler scheduler, INotificationPermission permission, INotificationChannelRegistry channels)
        {
            _scheduler = scheduler;
            _permission = permission;
            _channels = channels;
            _delay = 10;
        }

        [DeveloperOption("Schedule Test")]
        private void ScheduleTest()
        {
            if (!_isChannelRegistered)
            {
                _channels.Register(new NotificationChannel(ChannelId, "Developer Tools", "Test notifications from the developer tools", NotificationImportance.Default));
                _isChannelRegistered = true;
            }

            _scheduler.Schedule(new NotificationRequest(new NotificationId(NotificationId), "Test notification", "Sent from the developer tools", DateTime.Now.AddSeconds(_delay), ChannelId));
        }

        [DeveloperOption("Request Permission")]
        private void RequestPermission()
        {
            _permission.Request();
        }

        [DeveloperOption("Cancel All")]
        private void CancelAll()
        {
            _scheduler.CancelAll();
        }
    }
}
