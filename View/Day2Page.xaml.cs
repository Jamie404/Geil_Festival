using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;
using L00150620_Geil_Festival.Model;
using System.Data;

namespace L00150620_Geil_Festival.View;

public partial class Day2Page : ContentPage
{
    private Day2ViewModel ViewModel { get; set; }
    private ObservableCollection<Day2> filteredList = new ObservableCollection<Day2>();
    public Day2Page(Day2ViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetDay2Command.Execute(viewModel);

        this.ViewModel = viewModel;
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = BarSearch.Text.ToLower();

        var searchQuery = ViewModel.Day2.Where(s => s.bandName.ToLower().Contains(searchTerm) || s.stage.Contains(searchTerm) || s.time.Contains(searchTerm));
        filteredList.Clear();

        foreach (Day2 b in searchQuery)
        {
            filteredList.Add(b);
        }

        Day2View.ItemsSource = filteredList;
    }
}