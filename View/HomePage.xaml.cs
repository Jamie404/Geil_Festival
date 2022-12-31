namespace L00150620_Geil_Festival.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(bandsPage));
    }

    private async void ImageButton_Clicked1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Scheduler));

    }
    private async void ImageButton_Clicked2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Stages));

    }
}