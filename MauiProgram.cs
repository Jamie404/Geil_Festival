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
        builder.Services.AddSingleton<Day2Service>();
        builder.Services.AddSingleton<StageService>();
        builder.Services.AddSingleton<SponsorService>();
        builder.Services.AddSingleton<VendorService>();

        // Register the ViewModels
        builder.Services.AddSingleton<BandViewModel>();
        builder.Services.AddSingleton<Day1ViewModel>();
        builder.Services.AddSingleton<Day2ViewModel>();
        builder.Services.AddSingleton<StageViewModel>();
        builder.Services.AddSingleton<SponsorsViewModel>();
        builder.Services.AddSingleton<VendorsViewModel>();

        // Register the View Pages
        builder.Services.AddSingleton<FlyoutShellPage>();
        builder.Services.AddSingleton<bandsPage>();
        builder.Services.AddSingleton<Day1Page>();
        builder.Services.AddSingleton<Day2Page>();
        builder.Services.AddSingleton<Stages>();
        builder.Services.AddSingleton<Sponsors>();
        builder.Services.AddSingleton<Vendors>();

        return builder.Build();
    }
}
