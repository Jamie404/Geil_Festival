using L00150620_Geil_Festival.ViewModel;
using System.Collections.ObjectModel;
using L00150620_Geil_Festival.Model;
using System.Data;
using System.Text.Json;

namespace L00150620_Geil_Festival.View;

public partial class Day2Page : ContentPage
{
    private Day2ViewModel ViewModel { get; set; }
    private ObservableCollection<Day2> filteredList = new ObservableCollection<Day2>();
    private Day2ViewModel ViewModel2 { get; set; }
    private ObservableCollection<Day2> testList = new ObservableCollection<Day2>();
    public Day2Page(Day2ViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetDay2Command.Execute(viewModel);

        this.ViewModel = viewModel;
        this.ViewModel2= viewModel;
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
    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var test = ViewModel2.Day2.Where(s => s.saved.Equals(true));
        testList.Clear();

        foreach (Day2 b in test)
        {
            testList.Add(b);
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(test, options);



        // ***IMPORTANT - Comment out Android code if running on Windows OS - Lines 59 + 60

        // FOR ANDROID - Writes to Virtual SD card application documents directory
        // REQUIRES VIRTUAL SD CARD CONFIGURATION ON EMULATOR

        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
        File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/test2.json", jsonString);


        // FOR WINDOWS - Writes to User Local Data

        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "test2.json");
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);
        await streamWriter.WriteAsync(jsonString);
    }
}