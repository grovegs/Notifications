using System.Collections.Generic;
using GroveGames.Notifications;

namespace GroveGames.Notifications.Testing
{
    public sealed class FakeNotificationChannelRegistry : INotificationChannelRegistry
    {
        private readonly List<string> _channelIds = new();

        public IReadOnlyList<string> ChannelIds => _channelIds;

        public void Register(in NotificationChannel channel)
        {
            _channelIds.Add(channel.Id);
        }
    }
}
