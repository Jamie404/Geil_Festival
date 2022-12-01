using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class BandViewModel : BaseViewModel
    {
        BandService _bandService;

        public ObservableCollection<Model.Band> Band { get; } = new();

        public Command GetBandCommand { get; }

        public BandViewModel(BandService bandService)
        {
            _bandService = bandService;

            GetBandCommand = new Command(async () => await GetBandAsync());
        }

        async Task GetBandAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var bands = await _bandService.GetBandFileAsync();
                if (bands.Count != 0)
                    bands.Clear();

                foreach (var band in bands)
                    Band.Add(band);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Display an alert if an exception is raised
                await Shell.Current.DisplayAlert("Error", "Unable to get bands/artists", "OK");
            }
            finally
            {
                // Finish/clean up code here
                IsBusy = false;
            }
        }
    }
}
