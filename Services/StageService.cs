using L00150620_Geil_Festival.Model;
using System.Text.Json;

namespace L00150620_Geil_Festival.Services
{
    public class StageService
    {
        // List of Band objects
        List<Stages> _stageList = new List<Stages>();

        public StageService()
        {

        }

        public async Task<List<Stages>> GetStageFileAsync()
        {
            if (_stageList.Count > 0)
            {
                return _stageList;
            }
            using var stream = await FileSystem.OpenAppPackageFileAsync("stages.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            _stageList = JsonSerializer.Deserialize<List<Stages>>(contents);

            return _stageList;
        }
    }
}
