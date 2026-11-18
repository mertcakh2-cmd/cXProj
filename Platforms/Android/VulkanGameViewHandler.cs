using Microsoft.Maui.Handlers;
using Microsoft.Maui;
using MyMAUI.Engine.Views;

namespace MyMAUI.Platforms.Android;

public class VulkanGameViewHandler
    : ViewHandler<VulkanGameView, AndroidGameSurfaceView>
{
    public VulkanGameViewHandler()
        : base(new PropertyMapper<VulkanGameView, VulkanGameViewHandler>(ViewMapper))
    {
    }

    protected override AndroidGameSurfaceView CreatePlatformView()
    {
        return new AndroidGameSurfaceView(
            MauiContext!.Context
        );
    }
}
