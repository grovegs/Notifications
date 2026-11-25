---
name: grovegames-notifications
description: Rules for local notifications in game code with GroveGames.Notifications. Use when writing or reviewing code that schedules or cancels a notification, asks for the notification permission, registers a channel, or reacts to the app being opened from a notification.
---

# Using GroveGames.Notifications

Rules for game code that uses this package. They hold in every game. The API is in the package's `README.md`.

- Game code talks to `INotificationScheduler`, `INotificationPermission`, `INotificationChannelRegistry` and `INotificationLaunchSource`, taken through the constructor. Never call a platform notification API.
- Register every channel once at startup, before the first `Schedule`.
- Ask for the permission at a moment the player understands, never on first launch. `Request()` does not block: read `Status` until it leaves `Pending`, then branch on `Granted`, `Denied` and `DeniedPermanently`. Do not ask again after `DeniedPermanently`.
- A notification id is a constant per kind of notification, such as `"stash.full"`. Scheduling the same id again replaces the pending one, so reschedule instead of cancelling first.
- Schedule from the time the player will actually be away: when the app goes to the background, with the fire time worked out from game state. Cancel what no longer applies when the app comes back.
- Read `ConsumeLaunchPayload()` at startup. It returns the payload only the first time. On iOS it returns `null` until the system has answered, so read it again on a later frame before deciding there was none.
- The payload is a short route such as `"stash"`, never player data.
