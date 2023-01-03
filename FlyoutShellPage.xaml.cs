// Author: L00150620 - Jamie McGee
// Class: Applied Computing
// Module: Cross-Platform Development
// Lecturer: Dr. Shane Wilson

using L00150620_Geil_Festival.View;

namespace L00150620_Geil_Festival;

public partial class FlyoutShellPage : Shell
{

    public FlyoutShellPage()
	{
		InitializeComponent();

        // Creates routes for home page image on click functions to navigate to appropriate page
        Routing.RegisterRoute(nameof(bandsPage), typeof(bandsPage));
        Routing.RegisterRoute(nameof(Stages), typeof(Stages));
        Routing.RegisterRoute(nameof(Vendors), typeof(Vendors));
    }
}