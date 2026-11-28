namespace GroveGames.Notifications;

public sealed class NullNotificationPermission : INotificationPermission
{
    public NotificationPermissionStatus Status => NotificationPermissionStatus.DeniedPermanently;

    public void Request()
    {
    }
}
