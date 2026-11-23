namespace GroveGames.Notifications;

public readonly struct NotificationChannel
{
    private readonly string _id;
    private readonly string _name;
    private readonly string _description;
    private readonly NotificationImportance _importance;
    public string Id => _id;
    public string Name => _name;
    public string Description => _description;
    public NotificationImportance Importance => _importance;

    public NotificationChannel(string id, string name, string description, NotificationImportance importance)
    {
        _id = id;
        _name = name;
        _description = description;
        _importance = importance;
    }
}
