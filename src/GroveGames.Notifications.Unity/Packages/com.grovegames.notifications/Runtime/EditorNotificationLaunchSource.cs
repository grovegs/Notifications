#if UNITY_EDITOR
namespace GroveGames.Notifications.Unity
{
    public sealed class EditorNotificationLaunchSource : INotificationLaunchSource
    {
        public string? ConsumeLaunchPayload()
        {
            return null;
        }
    }
}
#endif
