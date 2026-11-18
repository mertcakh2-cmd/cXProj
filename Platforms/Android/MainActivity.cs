using Android.App;
using Android.Content.PM;

using Microsoft.Maui;

namespace MyMAUI;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    Exported = true,
    ScreenOrientation = ScreenOrientation.Landscape,
    ConfigurationChanges =
        ConfigChanges.ScreenSize |
        ConfigChanges.Orientation |
        ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize |
        ConfigChanges.Density
)]
public class MainActivity : MauiAppCompatActivity
{
}
