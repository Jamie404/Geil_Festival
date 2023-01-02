using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class Day2ScheduleViewModel : BaseViewModel
    {
        Day2ScheduleService _day2ScheduleService;
        public ObservableCollection<Model.Day2Sched> Day2Schedule { get; } = new();
        public Command GetDay2ScheduleCommand { get; }

        public Day2ScheduleViewModel(Day2ScheduleService day2ScheduleService)
        {
            _day2ScheduleService = day2ScheduleService;
            GetDay2ScheduleCommand = new Command(async () => await GetDay2ScheduleAsync());
        }

        async Task GetDay2ScheduleAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var gigs = await _day2ScheduleService.GetDay2ScheduleFileAsync();
                if (gigs.Count != 0)
                    Day2Schedule.Clear();

                foreach (var gig in gigs)
                    Day2Schedule.Add(gig);
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
