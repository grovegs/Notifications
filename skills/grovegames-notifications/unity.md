## Unity

- The models and interfaces are in the `GroveGames.Notifications` namespace. `GroveGames.Notifications.Unity` holds the Android, iOS and Editor implementations.
- Register with `builder.AddNotifications()` in the root installer. It picks the implementations for the current platform; in the Editor they do nothing.
- A repeating notification on iOS needs a `RepeatInterval` of at least 60 seconds.
- An asmdef that overrides references lists `GroveGames.Notifications.dll` in its precompiled references.
