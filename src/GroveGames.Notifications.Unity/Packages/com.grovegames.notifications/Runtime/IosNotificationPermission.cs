#if UNITY_IOS
using Unity.Notifications.iOS;

namespace GroveGames.Notifications.Unity
{
    public sealed class IosNotificationPermission : INotificationPermission
    {
        private AuthorizationRequest? _request;

        public NotificationPermissionStatus Status
        {
            get
            {
                if (_request != null)
                {
                    if (!_request.IsFinished)
                    {
                        return NotificationPermissionStatus.Pending;
                    }

                    _request.Dispose();
                    _request = null;
                }

                return iOSNotificationCenter.GetNotificationSettings().AuthorizationStatus switch
                {
                    AuthorizationStatus.Authorized => NotificationPermissionStatus.Granted,
                    AuthorizationStatus.Provisional => NotificationPermissionStatus.Granted,
                    AuthorizationStatus.Denied => NotificationPermissionStatus.Denied,
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

            if (iOSNotificationCenter.GetNotificationSettings().AuthorizationStatus == AuthorizationStatus.Authorized)
            {
                return;
            }

            _request = new AuthorizationRequest(
                AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound,
                registerForRemoteNotifications: false);
        }
    }
}
#endif
