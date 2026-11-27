using System.Collections.Generic;
using GroveGames.Notifications;

namespace GroveGames.Notifications.Testing
{
    public sealed class FakeNotificationScheduler : INotificationScheduler
    {
        private readonly Dictionary<string, NotificationRequest> _scheduled;

        public FakeNotificationScheduler()
        {
            _scheduled = new Dictionary<string, NotificationRequest>();
        }

        public IReadOnlyDictionary<string, NotificationRequest> Scheduled => _scheduled;

        public void Schedule(in NotificationRequest request)
        {
            _scheduled[request.Id] = request;
        }

        public void Cancel(NotificationId id)
        {
            _scheduled.Remove(id);
        }

        public void CancelAll()
        {
            _scheduled.Clear();
        }
    }
}
