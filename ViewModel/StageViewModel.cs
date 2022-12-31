using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class StageViewModel : BaseViewModel
    {
        StageService _stageService;

        public ObservableCollection<Model.Stages> Stage { get; } = new();

        public Command GetStageCommand { get; }

        public StageViewModel(StageService stageService)
        {

            _stageService = stageService;

            GetStageCommand = new Command(async () => await GetStageAsync());

        }

        async Task GetStageAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var stages = await _stageService.GetStageFileAsync();
                if (stages.Count != 0)
                    Stage.Clear();

                foreach (var stage in stages)
                    Stage.Add(stage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Display an alert if an exception is raised
                await Shell.Current.DisplayAlert("Error", "Unable to get Stages", "OK");
            }
            finally
            {
                // Finish/clean up code here
                IsBusy = false;
            }
        }
    }
}
