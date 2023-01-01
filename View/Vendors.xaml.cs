using L00150620_Geil_Festival.ViewModel;

namespace L00150620_Geil_Festival.View;

public partial class Vendors : ContentPage
{
	public Vendors(VendorsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetVendorsCommand.Execute(viewModel);
    }
}