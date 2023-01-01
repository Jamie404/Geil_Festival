using L00150620_Geil_Festival.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace L00150620_Geil_Festival.ViewModel
{
    public class VendorsViewModel : BaseViewModel
    {
        VendorService _vendorService;

        public ObservableCollection<Model.Vendors> Vendor { get; } = new();

        public Command GetVendorsCommand { get; }

        public VendorsViewModel(VendorService vendorService)
        {

            _vendorService = vendorService;

            GetVendorsCommand = new Command(async () => await GetVendorAsync());

        }

        async Task GetVendorAsync()
        {
            // If busy, return only
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var vendors = await _vendorService.GetVendorFileAsyc();
                if (vendors.Count != 0)
                    Vendor.Clear();

                foreach (var vendor in vendors)
                    Vendor.Add(vendor);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // Display an alert if an exception is raised
                await Shell.Current.DisplayAlert("Error", "Unable to get Vendors", "OK");
            }
            finally
            {
                // Finish/clean up code here
                IsBusy = false;
            }
        }
    }
}
