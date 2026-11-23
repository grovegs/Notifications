#if UNITY_EDITOR
namespace GroveGames.Notifications.Unity
{
    public sealed class EditorNotificationScheduler : INotificationScheduler
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
}
#endif
