using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class Day2ViewModel : BaseViewModel
    {
        Day2Service _day2Service;
        public ObservableCollection<Model.Day2> Day2 { get; } = new();
        public Command GetDay2Command { get; }

        public Day2ViewModel(Day2Service day2Service)
        {
            _day2Service = day2Service;
            GetDay2Command = new Command(async () => await GetDay2Async());
        }

        async Task GetDay2Async()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var gigs = await _day2Service.GetDay2FileAsync();
                if (gigs.Count != 0)
                    Day2.Clear();

                foreach (var gig in gigs)
                    Day2.Add(gig);
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
