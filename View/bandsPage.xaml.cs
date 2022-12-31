using L00150620_Geil_Festival.Model;
using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;

namespace L00150620_Geil_Festival.View;

public partial class bandsPage : ContentPage
{
    private BandViewModel ViewModel { get; set; }
    private ObservableCollection<Band> filteredList = new ObservableCollection<Band>();


    public bandsPage(BandViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetBandCommand.Execute(viewModel);

        this.ViewModel = viewModel;
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = BarSearch.Text.ToLower();

        var searchQuery = ViewModel.Band.Where(s => s.name.ToLower().Contains(searchTerm) || s.genre.ToLower().Contains(searchTerm));
        filteredList.Clear();

        foreach (Band b in searchQuery)
        {
            filteredList.Add(b);
        }

        BandView.ItemsSource = filteredList;
    }
}