#if UNITY_ANDROID
using Unity.Notifications.Android;

namespace GroveGames.Notifications.Unity
{
    public sealed class AndroidNotificationPermission : INotificationPermission
    {
        private PermissionRequest? _request;

        public NotificationPermissionStatus Status
        {
            get
            {
                if (_request is { Status: PermissionStatus.RequestPending })
                {
                    return NotificationPermissionStatus.Pending;
                }

                _request = null;

                return AndroidNotificationCenter.UserPermissionToPost switch
                {
                    PermissionStatus.Allowed => NotificationPermissionStatus.Granted,
                    PermissionStatus.Denied => NotificationPermissionStatus.Denied,
                    PermissionStatus.DeniedDontAskAgain => NotificationPermissionStatus.DeniedPermanently,
                    PermissionStatus.RequestPending => NotificationPermissionStatus.Pending,
                    _ => NotificationPermissionStatus.NotRequested,
                };
            }
        }

        public void Request()
        {
            if (_request != null)
            {
                return;
            }

            if (AndroidNotificationCenter.UserPermissionToPost == PermissionStatus.Allowed)
            {
                return;
            }

            _request = new PermissionRequest();
        }
    }
}
#endif
