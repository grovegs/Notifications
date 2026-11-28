namespace GroveGames.Notifications.Tests;

public sealed class NullNotificationPermissionTests
{
    [Fact]
    public void Request_Unsupported_StaysDeniedPermanently()
    {
        var permission = new NullNotificationPermission();

        permission.Request();

        Assert.Equal(NotificationPermissionStatus.DeniedPermanently, permission.Status);
    }
}
