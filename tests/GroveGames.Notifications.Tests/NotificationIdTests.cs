namespace GroveGames.Notifications.Tests;

public sealed class NotificationIdTests
{
    [Fact]
    public void ImplicitString_Id_ReturnsTheText()
    {
        var id = new NotificationId("daily-reward");

        string text = id;

        Assert.Equal("daily-reward", text);
    }

    [Fact]
    public void ExplicitFromString_Text_KeepsTheText()
    {
        var id = (NotificationId)"daily-reward";

        string text = id;

        Assert.Equal("daily-reward", text);
    }

    [Theory]
    [InlineData("", -2128831035)]
    [InlineData("a", -468965076)]
    [InlineData("daily-reward", -1633843370)]
    public void ImplicitInt_Id_ReturnsTheSameHashOnEveryRun(string text, int expected)
    {
        var id = new NotificationId(text);

        int hash = id;

        Assert.Equal(expected, hash);
    }

    [Fact]
    public void ImplicitInt_DifferentIds_ReturnDifferentHashes()
    {
        int first = new NotificationId("daily-reward");
        int second = new NotificationId("stash-full");

        Assert.NotEqual(first, second);
    }
}
