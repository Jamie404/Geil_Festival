using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class Day1Service
    {
        // List of Day 1 objects
        List<Day1> _day1List = new List<Day1>();

        public Day1Service()
        {

        }

        public async Task<List<Day1>> GetDay1FileAsync()
        {
            if (_day1List.Count > 0)
            {
                return _day1List;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("day1.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _day1List = JsonSerializer.Deserialize<List<Day1>>(contents);

            return _day1List;
        }
    }
}
