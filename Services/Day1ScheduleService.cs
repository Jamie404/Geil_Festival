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
            _day1Schedule.Clear();

            if (_day1Schedule.Count > 0)
            {
                return _day1Schedule;
            }

            // ***IMPORTANT - Comment out Android if running on Windows

            // USE FOR WINDOWS
            //var targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "test.json");

            // USE FOR ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            var targetFile = Path.Combine($"{docsDirectory.AbsoluteFile.Path}/test.json");


            using var reader = new StreamReader(targetFile);
            var contents = await reader.ReadToEndAsync();
            _day1Schedule = JsonSerializer.Deserialize<List<Day1Sched>>(contents);

            return _day1Schedule;
        }
    }
}
