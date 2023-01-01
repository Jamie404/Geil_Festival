using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;
using L00150620_Geil_Festival.Model;
using System.Diagnostics;
using System.Text.Json;

namespace L00150620_Geil_Festival.View;

public partial class Day1Page : ContentPage
{
    private Day1ViewModel ViewModel { get; set; }
    private ObservableCollection<Day1> filteredList = new ObservableCollection<Day1>();

    private Day1ViewModel ViewModel2 { get; set; }
    private ObservableCollection<Day1> testList = new ObservableCollection<Day1>();

    public Day1Page(Day1ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetDay1Command.Execute(viewModel);

        this.ViewModel = viewModel;
        this.ViewModel2 = viewModel;
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = BarSearch.Text.ToLower();

        var searchQuery = ViewModel.Day1.Where(s => s.bandName.ToLower().Contains(searchTerm) || s.stage.Contains(searchTerm) || s.time.Contains(searchTerm));
        filteredList.Clear();

        foreach (Day1 b in searchQuery)
        {
            filteredList.Add(b);
        }

        Day1View.ItemsSource = filteredList;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        try
        {
            var searchQuery = ViewModel2.Day1.Where(s => s.saved.Equals(true));
            testList.Clear();

            foreach (Day1 b in searchQuery)
            {
                testList.Add(b);
            }

            Day1View.ItemsSource = testList;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Display an alert if an exception is raised
            Shell.Current.DisplayAlert("Error", "Unable to filter Bands / Artists", "OK");
        }
    }
}