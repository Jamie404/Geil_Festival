using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class Day2Service
    {
        // List of Day 1 objects
        List<Day2> _day2List = new List<Day2>();

        public Day2Service()
        {

        }

        public async Task<List<Day2>> GetDay2FileAsync()
        {
            if (_day2List.Count > 0)
            {
                return _day2List;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("day2.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _day2List = JsonSerializer.Deserialize<List<Day2>>(contents);

            return _day2List;
        }
    }
}
