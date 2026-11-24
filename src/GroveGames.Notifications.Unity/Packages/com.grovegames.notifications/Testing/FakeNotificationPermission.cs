using GroveGames.Notifications;

namespace GroveGames.Notifications.Testing
{
    public sealed class FakeNotificationPermission : INotificationPermission
    {
        private NotificationPermissionStatus _status = NotificationPermissionStatus.NotRequested;
        private int _requestCount;

        public NotificationPermissionStatus Status => _status;
        public int RequestCount => _requestCount;

        public void Request()
        {
            _requestCount++;
            _status = NotificationPermissionStatus.Pending;
        }
    }
}
