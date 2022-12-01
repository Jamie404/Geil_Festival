using L00150620_Geil_Festival.ViewModel;
namespace L00150620_Geil_Festival.View;

public partial class HomePage : ContentPage
{
	public HomePage(BandViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}