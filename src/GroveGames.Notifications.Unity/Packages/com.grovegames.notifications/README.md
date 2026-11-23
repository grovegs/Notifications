# GroveGames.Notifications

[![Build Status](https://github.com/grovegs/Notifications/actions/workflows/release.yml/badge.svg)](https://github.com/grovegs/Notifications/actions/workflows/release.yml)
[![Tests](https://github.com/grovegs/Notifications/actions/workflows/tests.yml/badge.svg)](https://github.com/grovegs/Notifications/actions/workflows/tests.yml)
[![NuGet](https://img.shields.io/nuget/v/GroveGames.Notifications)](https://www.nuget.org/packages/GroveGames.Notifications)
[![Latest Release](https://img.shields.io/github/v/release/grovegs/Notifications)](https://github.com/grovegs/Notifications/releases/latest)

Local notifications for mobile games: scheduling, permission, channels and the launch payload, for .NET and Unity

## Features

- `INotificationScheduler`: schedule, replace and cancel local notifications
- `INotificationPermission`: read and request the permission to post, without blocking
- `INotificationChannelRegistry`: register the channels a notification is posted to
- `INotificationLaunchSource`: read, once, the payload of the notification that opened the app
- Unity: implementations for Android and iOS on top of `com.unity.mobile.notifications`, and implementations that do nothing for the Editor

## .NET

### Installation

```bash
dotnet add package GroveGames.Notifications
```

### Usage

The core holds the models and the four interfaces. An engine package implements them.

```csharp
using GroveGames.Notifications;

channelRegistry.Register(new NotificationChannel("retention", "Reminders", "Come back reminders", NotificationImportance.Default));

if (permission.Status == NotificationPermissionStatus.NotRequested)
{
    permission.Request();
}

scheduler.Schedule(new NotificationRequest(
    new NotificationId("retention.daily"),
    "Your picnic awaits",
    "The ants are back.",
    DateTime.Now.AddHours(24),
    "retention",
    payload: "home"));

var payload = launchSource.ConsumeLaunchPayload();
```

- `Request()` starts the system dialog and returns at once. Read `Status` until it leaves `Pending`.
- Scheduling with an id that is already scheduled replaces that notification.
- `ConsumeLaunchPayload()` returns the payload the first time it is called and `null` after that.

## Unity

### Installation

1. Install the core package via [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity):
   - Open Window > NuGet > Manage NuGet Packages
   - Search for `GroveGames.Notifications` and install

2. Add the Unity package via Git URL:
   - Open Package Manager (Window > Package Manager)
   - Click "+" > "Add package from git URL"
   - Enter: `https://github.com/grovegs/Notifications.git?path=src/GroveGames.Notifications.Unity/Packages/com.grovegames.notifications`

3. Create a `csc.rsp` file in your `Assets/` directory with the following content to enable C# 10 features:

   ```text
   -langversion:10
   -nullable:enable
   ```

### Usage

With [GroveGames.DependencyInjection](https://github.com/grovegs/DependencyInjection) installed, `AddNotifications()` registers the scheduler, the permission and the channel registry for the current platform. Register the `INotificationLaunchSource` implementation yourself:

```csharp
using GroveGames.Notifications.Unity;

builder.AddNotifications();
```

### Platform notes

- Android notification ids come from the text of `NotificationId` through a stable FNV-1a hash.
- `ChannelId` is a notification channel on Android and the category identifier on iOS. Registering a channel does nothing on iOS.
- A repeating notification on iOS needs a `RepeatInterval` of at least 60 seconds.
- Cancelling removes the scheduled notification and the delivered one.

## Development

### Project Structure

- `src/GroveGames.Notifications/` - Core .NET library (`net10.0`, `netstandard2.1`)
- `src/GroveGames.Notifications.Unity/` - Unity package
- `tests/` - xUnit tests
- `sandbox/` - Sample applications for testing

### Commands

```bash
dotnet build                        # Build all projects
dotnet format                       # Format code
dotnet test                         # Run tests
dotnet pack -c Release              # Create NuGet packages
```

### Requirements

- .NET 10.0 SDK

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
