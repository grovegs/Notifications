namespace GroveGames.Notifications;

public interface INotificationLaunchSource
{
    public string? ConsumeLaunchPayload();
}
