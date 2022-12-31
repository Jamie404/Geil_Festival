using CommunityToolkit.Mvvm.ComponentModel;
using L00150620_Geil_Festival.Model;

namespace L00150620_Geil_Festival.ViewModel
{
    [QueryProperty(nameof(Band), "Band")]
    public partial class Day1DetailsViewModel : BaseViewModel
    {
        public Day1DetailsViewModel()
        {

        }

        [ObservableProperty]
        Band band;
    }
}
