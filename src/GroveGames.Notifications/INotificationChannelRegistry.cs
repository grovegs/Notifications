namespace GroveGames.Notifications;

public interface INotificationChannelRegistry
{
    public void Register(in NotificationChannel channel);
}
