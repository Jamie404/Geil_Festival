// Author: L00150620 - Jamie McGee
// Class: Applied Computing
// Module: Cross-Platform Development
// Lecturer: Dr. Shane Wilson
// GIT TEST

using L00150620_Geil_Festival.Services;
using L00150620_Geil_Festival.View;
using L00150620_Geil_Festival.ViewModel;

namespace L00150620_Geil_Festival;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register the Services
        builder.Services.AddSingleton<BandService>();
        builder.Services.AddSingleton<Day1Service>();

        // Register the ViewModels
        builder.Services.AddSingleton<BandViewModel>();
        builder.Services.AddSingleton<Day1ViewModel>();

        // Register the View Pages
        builder.Services.AddSingleton<FlyoutShellPage>();
        builder.Services.AddSingleton<bandsPage>();
        builder.Services.AddSingleton<Day1>();

        return builder.Build();
    }
}
