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
        // Register the BandService
        builder.Services.AddSingleton<BandService>();
        // Register the viewModel
        builder.Services.AddSingleton<BandViewModel>();
        // Register the MainPage
        builder.Services.AddTransient<FlyoutShellPage>();
        // Register the bandsPage
        builder.Services.AddTransient<bandsPage>();

        return builder.Build();
    }
}
