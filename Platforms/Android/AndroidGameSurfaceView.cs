using Android.Content;
using Android.Graphics;
using Android.Views;

namespace MyMAUI.Platforms.Android;

public sealed class AndroidGameSurfaceView :
    SurfaceView,
    ISurfaceHolderCallback
{
    public event Action<string>? StatusChanged;

    public AndroidGameSurfaceView(Context context)
        : base(context)
    {
        Holder.AddCallback(this);

        Focusable = true;
        FocusableInTouchMode = true;
    }

    public void SurfaceCreated(ISurfaceHolder holder)
    {
        StatusChanged?.Invoke(
            VulkanBootstrap.Initialize()
        );
    }

    public void SurfaceChanged(
        ISurfaceHolder holder,
        Format format,
        int width,
        int height)
    {
        // Vulkan swapchain resizing will be handled
        // by our rendering system.
    }

    public void SurfaceDestroyed(ISurfaceHolder holder)
    {
        StatusChanged?.Invoke("ANDROID SURFACE PAUSED");
    }
}
