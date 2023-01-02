using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class Day2ScheduleService
    {
        // List of Day 1 Schedule objects
        List<Day2Sched> _day2Schedule = new List<Day2Sched>();

        public Day2ScheduleService()
        {

        }

        public async Task<List<Day2Sched>> GetDay2ScheduleFileAsync()
        {
            if (_day2Schedule.Count > 0)
            {
                return _day2Schedule;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("day2.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _day2Schedule = JsonSerializer.Deserialize<List<Day2Sched>>(contents);

            return _day2Schedule;
        }
    }
}
