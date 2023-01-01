using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class VendorService
    {
        // List of Band objects
        List<Vendors> _vendorList = new List<Vendors>();

        public VendorService()
        {

        }

        public async Task<List<Vendors>> GetVendorFileAsyc()
        {
            if (_vendorList.Count > 0)
            {
                return _vendorList;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("vendors.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _vendorList = JsonSerializer.Deserialize<List<Vendors>>(contents);

            return _vendorList;
        }
    }
}
