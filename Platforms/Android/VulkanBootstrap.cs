using Silk.NET.Vulkan;

namespace MyMAUI.Platforms.Android;

public static unsafe class VulkanBootstrap
{
    private static Vk? _vk;
    private static Instance _instance;

    public static bool IsInitialized { get; private set; }

    public static string Status { get; private set; } =
        "Vulkan not initialized";

    public static bool Initialize()
    {
        try
        {
            _vk = Vk.GetApi();

            ApplicationInfo appInfo = new()
            {
                SType = StructureType.ApplicationInfo,
                PApplicationName = (byte*)0,
                ApplicationVersion = 1,
                PEngineName = (byte*)0,
                EngineVersion = 1,
                ApiVersion = Vk.Version10
            };

            InstanceCreateInfo createInfo = new()
            {
                SType = StructureType.InstanceCreateInfo,
                PApplicationInfo = &appInfo
            };

            Result result = _vk.CreateInstance(
                &createInfo,
                null,
                out _instance
            );

            if (result != Result.Success)
            {
                Status = $"Vulkan failed: {result}";
                return false;
            }

            IsInitialized = true;
            Status = "Vulkan instance created";

            return true;
        }
        catch (Exception ex)
        {
            Status = ex.Message;
            return false;
        }
    }

    public static void Shutdown()
    {
        if (_vk != null && IsInitialized)
        {
            _vk.DestroyInstance(_instance, null);
            IsInitialized = false;
        }

        _vk?.Dispose();
        _vk = null;
    }
}
