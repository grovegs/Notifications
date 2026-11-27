using GroveGames.Notifications;

namespace GroveGames.Notifications.Testing
{
    public sealed class FakeNotificationLaunchSource : INotificationLaunchSource
    {
        private string? _payload;

        public FakeNotificationLaunchSource()
        {
            _payload = null;
        }

        public void SetLaunchPayload(string? payload)
        {
            _payload = payload;
        }

        public string? ConsumeLaunchPayload()
        {
            var payload = _payload;
            _payload = null;
            return payload;
        }
    }
}
