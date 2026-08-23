using Confluent.Kafka;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using IrongridProducer.Serivces;
public class Program
{
    static async Task Main(string[] args)
    {

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        string bootstrapServers = config["Kafka:BootstrapServers"];
        string uavTopic = config["Kafka:Topics:uav"];
        string perimeterTopic = config["Kafka:Topics:perimetersensor"];

        var dataloader = new LoadDataService();
        var assetData = dataloader.LoadUavData("Data/fieldreport.json");

        Console.WriteLine($"asset items loaded: {assetData.Count}");


        var produser = new ProducerService(bootstrapServers);
        await produser.EnsureTopicExistsAsync(uavTopic, bootstrapServers);
        await produser.EnsureTopicExistsAsync(perimeterTopic, bootstrapServers);
        int maxiLength = assetData.Count;
        for (int i = 0; i < maxiLength; i++)
        {
            if (assetData[i].AssetType == "UAV")
            {
                await produser.SendAsync(uavTopic, assetData[i]);
            }
            if (assetData[i].AssetType == "PerimeterSensor")
            {
                await produser.SendAsync(perimeterTopic, assetData[i]);
            }
        }
        produser.Dispose();
        await Task.Delay(3000);
        Console.WriteLine("all events save saccessfuly");
    }


        
       
}
