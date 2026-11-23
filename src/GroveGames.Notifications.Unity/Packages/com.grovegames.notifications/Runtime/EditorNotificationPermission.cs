#if UNITY_EDITOR
namespace GroveGames.Notifications.Unity
{
    public sealed class EditorNotificationPermission : INotificationPermission
    {
        public NotificationPermissionStatus Status => NotificationPermissionStatus.Granted;

        public void Request()
        {
        }
    }
}
#endif
