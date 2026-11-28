namespace GroveGames.Notifications;

public sealed class NullNotificationScheduler : INotificationScheduler
{
    public void Schedule(in NotificationRequest request)
    {
    }

    public void Cancel(NotificationId id)
    {
    }

    public void CancelAll()
    {
    }
}
