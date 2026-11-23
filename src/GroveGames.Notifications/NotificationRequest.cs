using System;

namespace GroveGames.Notifications;

public readonly struct NotificationRequest
{
    private readonly NotificationId _id;
    private readonly string _title;
    private readonly string _body;
    private readonly DateTime _fireTime;
    private readonly string _channelId;
    private readonly string? _payload;
    private readonly TimeSpan? _repeatInterval;
    public NotificationId Id => _id;
    public string Title => _title;
    public string Body => _body;
    public DateTime FireTime => _fireTime;
    public string ChannelId => _channelId;
    public string? Payload => _payload;
    public TimeSpan? RepeatInterval => _repeatInterval;

    public NotificationRequest(
        NotificationId id,
        string title,
        string body,
        DateTime fireTime,
        string channelId,
        string? payload = null,
        TimeSpan? repeatInterval = null)
    {
        _id = id;
        _title = title;
        _body = body;
        _fireTime = fireTime;
        _channelId = channelId;
        _payload = payload;
        _repeatInterval = repeatInterval;
    }
}
