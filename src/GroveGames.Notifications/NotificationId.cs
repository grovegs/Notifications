namespace GroveGames.Notifications;

public readonly struct NotificationId
{
    private readonly string _id;

    public NotificationId(string id)
    {
        _id = id;
    }

    public static implicit operator string(NotificationId id) => id._id;
    public static explicit operator NotificationId(string id) => new(id);
    public static implicit operator int(NotificationId id) => id.ComputeHash();

    private int ComputeHash()
    {
        unchecked
        {
            const uint OffsetBasis = 2166136261u;
            const uint Prime = 16777619u;

            var hash = OffsetBasis;

            for (var i = 0; i < _id.Length; i++)
            {
                hash ^= _id[i];
                hash *= Prime;
            }

            return (int)hash;
        }
    }
}
