using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;
using L00150620_Geil_Festival.Model;
using System.Diagnostics;

namespace L00150620_Geil_Festival.View;

public partial class Day2Schedule : ContentPage
{
    private Day2ScheduleViewModel ViewModel { get; set; }
    private ObservableCollection<Day2Sched> filteredList = new ObservableCollection<Day2Sched>();

    private Day2ScheduleViewModel ViewModel2 { get; set; }
    private ObservableCollection<Day2Sched> testList = new ObservableCollection<Day2Sched>();

    public Day2Schedule(Day2ScheduleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetDay2ScheduleCommand.Execute(viewModel);

        Day1View.IsVisible = false;

        this.ViewModel = viewModel;
        this.ViewModel2 = viewModel;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        try
        {
            var searchQuery = ViewModel2.Day2Schedule.Where(s => s.saved.Equals(true));
            testList.Clear();

            foreach (Day2Sched b in searchQuery)
            {
                testList.Add(b);
            }

            Day1View.ItemsSource = testList;

            Console.WriteLine(testList);


            checkLabel.IsVisible= false;
            checkBox1.IsVisible= false;
            Day1View.IsVisible= true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Display an alert if an exception is raised
            Shell.Current.DisplayAlert("Error", "Unable to filter Bands / Artists", "OK");
        }
    }
}