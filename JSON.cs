using ConsoleApp01Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ConsoleApp01Projet
{
    internal static class JSON
    {
        private const string JSON_EXTENSION = ".json";

        public static void SaveData(object data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);

            try
            {
                using (StreamWriter writer = new StreamWriter(Campus.FilePath, false))
                {
                    writer.Write(json);
                }

                Logger.Write($"Data saved to {Campus.FilePath}.");
            }
            catch (Exception ex)
            {
                Logger.Write($"Failed to save data to {Campus.FilePath}: {ex.Message}");
                Campus.IsExiting = true;
            }
        }


        public static DataModel? LoadData()
        {
            var filePath = Campus.FilePath;
            Logger.Write($"Loading data from {filePath}...");

            if (!Path.IsPathRooted(filePath) || filePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                Logger.Write($"Invalid file path: {filePath}");
                return null;
            }

            if (!filePath.EndsWith(JSON_EXTENSION))
            {
                Logger.Write($"Invalid JSON file path: {filePath}");
                return null;
            }

            try
            {
                using (var fileStream = File.OpenText(filePath))
                {
                    var json = fileStream.ReadToEnd();
                    Logger.Write("Data loaded successfully.");
                    return JsonConvert.DeserializeObject<DataModel>(json);
                }
            }
            catch (Exception ex)
            {
                Logger.Write($"Failed to load data from {filePath}: {ex.Message}");
                return null;
            }
        }
    }
}
