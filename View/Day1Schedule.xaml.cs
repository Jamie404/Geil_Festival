using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;
using L00150620_Geil_Festival.Model;
using System.Diagnostics;

namespace L00150620_Geil_Festival.View;

public partial class Day1Schedule : ContentPage
{
    private Day1ScheduleViewModel ViewModel { get; set; }
    private ObservableCollection<Day1Sched> filteredList = new ObservableCollection<Day1Sched>();

    private Day1ScheduleViewModel ViewModel2 { get; set; }
    private ObservableCollection<Day1Sched> testList = new ObservableCollection<Day1Sched>();

    public Day1Schedule(Day1ScheduleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetDay1ScheduleCommand.Execute(viewModel);

        Day1View.IsVisible = false;

        this.ViewModel = viewModel;
        this.ViewModel2 = viewModel;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        try
        {
            Day1View.ItemsSource = "";

            var searchQuery = ViewModel2.Day1Schedule.Where(s => s.saved.Equals(true));
            testList.Clear();

            foreach (Day1Sched b in searchQuery)
            {
                testList.Add(b);
            }

            Day1View.ItemsSource = testList;

            Day1View.IsVisible = true;
            checkBox1.IsChecked = false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Display an alert if an exception is raised
            Shell.Current.DisplayAlert("Error", "Unable to filter Bands / Artists", "OK");
        }
    }
}