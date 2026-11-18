using Microsoft.Extensions.Logging;
using MyMAUI.Engine.Views;

#if ANDROID
using MyMAUI.Platforms.Android;
#endif

namespace MyMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>();

#if ANDROID
        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<
                VulkanGameView,
                VulkanGameViewHandler>();
        });
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
