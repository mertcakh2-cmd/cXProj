using Microsoft.Maui;
using Microsoft.Maui.Hosting;

using MyMAUI.Engine.Views;
using MyMAUI.Platforms.Android;

namespace MyMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>();

        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<
                VulkanGameView,
                VulkanGameViewHandler>();
        });

        return builder.Build();
    }
}
