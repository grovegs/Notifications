namespace GroveGames.Notifications;

public interface INotificationPermission
{
    public NotificationPermissionStatus Status { get; }
    public void Request();
}
