using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Bomb
{
    public static class DataJsonProcessor
    {
        private const string Path = "result.json";

        private static string jsonString;

        private static List<Result> results;

        public static List<Result> LoadJson()
        {
            if (File.Exists(Path))
            {
                jsonString = File.ReadAllText(Path);
                results = JsonSerializer.Deserialize<List<Result>>(jsonString);
            }
            else
            {
                results = new List<Result>();
            }
            return results;
        }

        public static void RecordJson(List<Result> data)
        {
            jsonString = JsonSerializer.Serialize<List<Result>>(data);
            File.WriteAllText(Path, jsonString);
        }

        public static void AddResultToJsonFile(Result result)
        {
            results = LoadJson();
            results.Add(result);
            RecordJson(results);
        }
    }
}
