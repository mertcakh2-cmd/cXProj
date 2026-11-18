using System.Runtime.InteropServices;

using Silk.NET.Vulkan;

namespace MyMAUI.Platforms.Android;

internal static unsafe class VulkanBootstrap
{
    private static Vk? _vk;

    private static Instance _instance;

    private static bool _ready;

    private static readonly object Gate = new();

    public static string Initialize()
    {
        lock (Gate)
        {
            if (_ready)
                return "VULKAN INSTANCE READY";

            IntPtr appName =
                Marshal.StringToHGlobalAnsi("ULTRAKILL Mobile");

            IntPtr engineName =
                Marshal.StringToHGlobalAnsi("BloodEngine");

            try
            {
                _vk = Vk.GetApi();

                ApplicationInfo appInfo = new()
                {
                    SType = StructureType.ApplicationInfo,

                    PApplicationName = (byte*)appName,

                    ApplicationVersion = new Version32(1, 0, 0),

                    PEngineName = (byte*)engineName,

                    EngineVersion = new Version32(0, 1, 0),

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
                    _vk.Dispose();
                    _vk = null;

                    return $"VULKAN ERROR: {result}";
                }

                _ready = true;

                return "VULKAN INSTANCE READY | VERSION 1.0";
            }
            catch (Exception ex)
            {
                _vk?.Dispose();

                _vk = null;

                return "VULKAN FAILED: " + ex.Message;
            }
            finally
            {
                Marshal.FreeHGlobal(appName);

                Marshal.FreeHGlobal(engineName);
            }
        }
    }

    public static void Shutdown()
    {
        lock (Gate)
        {
            if (_vk == null)
                return;

            if (_ready)
            {
                _vk.DestroyInstance(_instance, null);

                _ready = false;
            }

            _vk.Dispose();

            _vk = null;
        }
    }
}
