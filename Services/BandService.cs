using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class BandService
    {
        // List of Band objects
        List<Band> _bandList = new List<Band>();

        public BandService()
        {

        }

        public async Task<List<Band>> GetBandFileAsync()
        {
            if(_bandList.Count > 0)
            {
                return _bandList;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("Bands.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _bandList = JsonSerializer.Deserialize<List<Band>>(contents);

            return _bandList;
        }
    }
}
