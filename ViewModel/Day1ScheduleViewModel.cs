using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class Day1ScheduleViewModel : BaseViewModel
    {
        Day1ScheduleService _day1ScheduleService;
        public ObservableCollection<Model.Day1Sched> Day1Schedule { get; } = new();
        public Command GetDay1ScheduleCommand { get; }

        public Day1ScheduleViewModel(Day1ScheduleService day1ScheduleService)
        {
            _day1ScheduleService = day1ScheduleService;
            GetDay1ScheduleCommand = new Command(async () => await GetDay1ScheduleAsync());
        }

        async Task GetDay1ScheduleAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var gigs = await _day1ScheduleService.GetDay1ScheduleFileAsync();
                if (gigs.Count != 0)
                    Day1Schedule.Clear();

                foreach (var gig in gigs)
                    Day1Schedule.Add(gig);
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
