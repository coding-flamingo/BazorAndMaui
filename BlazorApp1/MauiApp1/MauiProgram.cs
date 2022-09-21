using MauiApp1.Data;
using MauiApp1.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.LifecycleEvents;
namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddLocalization();
            builder.ConfigureLifecycleEvents(lifecycle =>
            {
#if WINDOWS
                    lifecycle
            .AddWindows(windows =>
                windows.OnPlatformMessage((app, args) => {
                    if (MauiApp1.Platforms.Windows.WindowExtensions.Hwnd == IntPtr.Zero)
                    {
                        MauiApp1.Platforms.Windows.WindowExtensions.Hwnd = args.Hwnd;
                        MauiApp1.Platforms.Windows.WindowExtensions.SetIcon("Platforms/Windows/trayicon.ico");
                    }
                     app.ExtendsContentIntoTitleBar = false;
                        }));
#endif
            });
            builder.Services.AddBlazorWebView();
            builder.Services.AddSingleton<WeatherForecastService>();

#if WINDOWS
            builder.Services.AddSingleton<ITrayService, MauiApp1.Platforms.Windows.TrayService>();
#endif
            return builder.Build();
        }
    }
}