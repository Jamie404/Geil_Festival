using L00150620_Geil_Festival.ViewModel;

namespace L00150620_Geil_Festival.View;

public partial class Stages : ContentPage
{
	public Stages(StageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetStageCommand.Execute(viewModel);
    }
}