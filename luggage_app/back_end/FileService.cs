using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace luggage_app.back_end
{
    public interface IFileService
    {
        void SaveToFile(Dictionary<int, Luggage> data);
        Dictionary<int, Luggage> LoadFromFile();
    }
    
    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveToFile(Dictionary<int, Luggage> data)
        {
            var lines = data
                .Select(pair => ConvertToLine((pair.Key, pair.Value)))
                .ToArray();
            File.WriteAllLines(_filePath, lines);
        }

        public Dictionary<int, Luggage> LoadFromFile()
        {
            var result = new Dictionary<int, Luggage>();
            var luggageList = File.ReadAllLines(_filePath).Select(ConvertToData);
            foreach (var (id, luggage) in luggageList)
            {
                result[id] = luggage;
            }
            return result;
        }

        private (int, Luggage) ConvertToData(string line)
        {
            var data = line.Split(",");
            var id = Convert.ToInt32(data[0]);
            var luggage = new Luggage(data[1], data[2],
                Convert.ToInt32(data[3]), Convert.ToDouble(data[4]));
            return (id, luggage);
        }
        
        private string ConvertToLine((int, Luggage) data)
        {
            return $"{data.Item1},{data.Item2.PassengerSurname},{data.Item2.Code},{data.Item2.ItemsAmount},{data.Item2.Weight}";
        }
    }
}