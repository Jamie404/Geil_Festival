using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class Day1ScheduleService
    {
        // List of Day 1 Schedule objects
        List<Day1Sched> _day1Schedule = new List<Day1Sched>();

        public Day1ScheduleService()
        {

        }

        public async Task<List<Day1Sched>> GetDay1ScheduleFileAsync()
        {
            if (_day1Schedule.Count > 0)
            {
                return _day1Schedule;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("day1.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _day1Schedule = JsonSerializer.Deserialize<List<Day1Sched>>(contents);

            return _day1Schedule;
        }
    }
}
