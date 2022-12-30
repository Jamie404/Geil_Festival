using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class Day1ViewModel : BaseViewModel
    {
        Day1Service _day1Service;
        public ObservableCollection<Model.Day1> Day1 { get; } = new();
        public Command GetDay1Command { get; }

        public Day1ViewModel(Day1Service day1Service)
        {
            _day1Service = day1Service;
            GetDay1Command = new Command(async () => await GetDay1Async());
        }

        async Task GetDay1Async()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var gigs = await _day1Service.GetDay1FileAsync();
                if (gigs.Count != 0)
                    Day1.Clear();

                foreach (var gig in gigs)
                    Day1.Add(gig);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Display an alert if an exception is raised
                await Shell.Current.DisplayAlert("Error", "Unable to get Bands / Artists", "OK");
            }
            finally
            {
                // Finish/clean up code here
                IsBusy = false;
            }
        }
    }
}
