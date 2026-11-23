namespace GroveGames.Notifications.Tests;

public sealed class NotificationRequestTests
{
    [Fact]
    public void Constructor_RequiredValues_LeavesPayloadAndRepeatEmpty()
    {
        var fireTime = new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);

        var request = new NotificationRequest(new NotificationId("daily-reward"), "Title", "Body", fireTime, "retention");

        Assert.Equal("daily-reward", (string)request.Id);
        Assert.Equal("Title", request.Title);
        Assert.Equal("Body", request.Body);
        Assert.Equal(fireTime, request.FireTime);
        Assert.Equal("retention", request.ChannelId);
        Assert.Null(request.Payload);
        Assert.Null(request.RepeatInterval);
    }

    [Fact]
    public void Constructor_PayloadAndRepeat_KeepsThem()
    {
        var request = new NotificationRequest(new NotificationId("stash-full"), "Title", "Body", DateTime.UnixEpoch, "retention", "open-stash", TimeSpan.FromDays(1));

        Assert.Equal("open-stash", request.Payload);
        Assert.Equal(TimeSpan.FromDays(1), request.RepeatInterval);
    }
}
