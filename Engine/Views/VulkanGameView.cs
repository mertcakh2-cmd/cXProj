using Microsoft.Maui.Controls;

namespace MyMAUI.Engine.Views;

public class VulkanGameView : View
{
    public event Action<string>? StatusChanged;

    internal void PublishStatus(string status)
    {
        StatusChanged?.Invoke(status);
    }
}
