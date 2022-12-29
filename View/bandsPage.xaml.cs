using L00150620_Geil_Festival.ViewModel;

namespace L00150620_Geil_Festival.View;

public partial class bandsPage : ContentPage
{
	public bandsPage(BandViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}