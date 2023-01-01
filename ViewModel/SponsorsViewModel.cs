using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class SponsorsViewModel : BaseViewModel
    {
        SponsorService _sponsorService;

        public ObservableCollection<Model.Sponsors> Sponsors { get; } = new();

        public Command GetSponsorsCommand { get; }

        public SponsorsViewModel(SponsorService sponsorService)
        {

            _sponsorService = sponsorService;

            GetSponsorsCommand = new Command(async () => await GetSponsorAsync());

        }

        async Task GetSponsorAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var sponsors = await _sponsorService.GetSponsorFileAsync();
                if (sponsors.Count != 0)
                    Sponsors.Clear();

                foreach (var sponsor in sponsors)
                    Sponsors.Add(sponsor);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Display an alert if an exception is raised
                await Shell.Current.DisplayAlert("Error", "Unable to get Sponsors", "OK");
            }
            finally
            {
                // Finish/clean up code here
                IsBusy = false;
            }
        }
    }
}
