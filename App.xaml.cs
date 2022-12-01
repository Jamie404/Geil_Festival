// Author: L00150620 - Jamie McGee
// Class: Applied Computing
// Module: Cross-Platform Development
// Lecturer: Dr. Shane Wilson

namespace L00150620_Geil_Festival;

public partial class App : Application
{
	public App()
	{
        
        InitializeComponent();
        // Placeholder in case of necessary colour comparisons.
        //Application.Current.UserAppTheme = AppTheme.Dark;

        MainPage = new FlyoutShellPage();
	}
}
