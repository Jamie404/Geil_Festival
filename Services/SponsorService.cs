using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class SponsorService
    {
        // List of Band objects
        List<Sponsors> _sponsorList = new List<Sponsors>();

        public SponsorService()
        {

        }

        public async Task<List<Sponsors>> GetSponsorFileAsync()
        {
            if (_sponsorList.Count > 0)
            {
                return _sponsorList;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("sponsors.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _sponsorList = JsonSerializer.Deserialize<List<Sponsors>>(contents);

            return _sponsorList;
        }
    }
}
