namespace L00150620_Geil_Festival.View;
using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;

public partial class Day1 : ContentPage
{
	public Day1(Day1ViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        viewModel.GetDay1Command.Execute(viewModel);

    }
}