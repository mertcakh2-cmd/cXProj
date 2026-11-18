using Microsoft.Maui.Handlers;
using MyMAUI.Engine.Views;

namespace MyMAUI.Platforms.Android;

public class VulkanGameViewHandler
    : ViewHandler<VulkanGameView, AndroidGameSurfaceView>
{
    protected override AndroidGameSurfaceView CreatePlatformView()
    {
        return new AndroidGameSurfaceView(MauiContext!.Context);
    }
}
