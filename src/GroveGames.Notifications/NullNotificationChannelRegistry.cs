namespace GroveGames.Notifications;

public sealed class NullNotificationChannelRegistry : INotificationChannelRegistry
{
    public void Register(in NotificationChannel channel)
    {
    }
}
