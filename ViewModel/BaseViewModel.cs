using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace L00150620_Geil_Festival.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool _isBusy;
        string _pageTitle;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy = value)
                    return;
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                if (_pageTitle == value)
                    return;
                _pageTitle = value;
            }
        }
        public bool IsNotBusy => !IsBusy;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
