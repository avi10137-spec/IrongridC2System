using IrongridProducer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace IrongridProducer.Serivces
{
    public class LoadDataService
    {
        public List<assetslivestatus> LoadUavData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<assetslivestatus>();
            }
            string TextFromJson = File.ReadAllText(filepath);

            if (string.IsNullOrWhiteSpace(TextFromJson))
            {
                return new List<assetslivestatus>();
            }
            var data = JsonSerializer.Deserialize<List<assetslivestatus>>(TextFromJson);
            return data;

        }
    }
}
