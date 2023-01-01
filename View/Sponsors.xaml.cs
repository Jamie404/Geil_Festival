using L00150620_Geil_Festival.ViewModel;

namespace L00150620_Geil_Festival.View;

public partial class Sponsors : ContentPage
{
	public Sponsors(SponsorsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetSponsorsCommand.Execute(viewModel);
    }
}