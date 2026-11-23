namespace GroveGames.Notifications;

public interface INotificationScheduler
{
    public void Schedule(in NotificationRequest request);
    public void Cancel(NotificationId id);
    public void CancelAll();
}
