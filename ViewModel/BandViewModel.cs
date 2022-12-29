using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace L00150620_Geil_Festival.ViewModel
{
    public class BandViewModel : BaseViewModel
    {
        BandService _bandService;

        public ObservableCollection<Model.Band> Band { get; } = new();

        public Command GetBandCommand { get; }
        public Command FilterCommand => new Command<string>(FilterItems);

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
                    Band.Clear();

                foreach (var band in bands)
                    Band.Add(band);
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

        void FilterItems(string filter)
        {
            var filteredItems = Band.Where(band => band.name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var band in Band)
            {
                Console.WriteLine(Band);
                if (!filteredItems.Contains(band))
                {
                    Band.Remove(band);
                    Console.WriteLine(Band);
                }
                else
                {
                    if (!Band.Contains(band))
                    {
                        Band.Add(band);
                        Console.WriteLine(Band);
                    }
                }
            }
        }
    }
}
