using GroveGames.DependencyInjection;
#if GROVEGAMES_DEVELOPERTOOLS
using GroveGames.DeveloperTools.Unity;
using GroveGames.Notifications.Unity.DeveloperTools;
#endif

namespace GroveGames.Notifications.Unity
{
    public static class NotificationsContainerBuilderExtensions
    {
        public static IContainerBuilder AddNotifications(this IContainerBuilder builder)
        {
#if UNITY_EDITOR
            builder.AddSingleton<INotificationScheduler, EditorNotificationScheduler>();
            builder.AddSingleton<INotificationPermission, EditorNotificationPermission>();
            builder.AddSingleton<INotificationChannelRegistry, EditorNotificationChannelRegistry>();
#elif UNITY_ANDROID
            builder.AddSingleton<INotificationScheduler, AndroidNotificationScheduler>();
            builder.AddSingleton<INotificationPermission, AndroidNotificationPermission>();
            builder.AddSingleton<INotificationChannelRegistry, AndroidNotificationChannelRegistry>();
#elif UNITY_IOS
            builder.AddSingleton<INotificationScheduler, IosNotificationScheduler>();
            builder.AddSingleton<INotificationPermission, IosNotificationPermission>();
            builder.AddSingleton<INotificationChannelRegistry, IosNotificationChannelRegistry>();
#else
            builder.AddSingleton<INotificationScheduler, NullNotificationScheduler>();
            builder.AddSingleton<INotificationPermission, NullNotificationPermission>();
            builder.AddSingleton<INotificationChannelRegistry, NullNotificationChannelRegistry>();
#endif
#if GROVEGAMES_DEVELOPERTOOLS
            builder.AddDeveloperOptions<NotificationsDeveloperOptions>();
#endif
            return builder;
        }
    }
}
