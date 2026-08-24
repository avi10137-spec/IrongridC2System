
using IrongridConsumer.Maping;
using IrongridConsumer.Services;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== assets Event Consumer ===\n");
        var configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false)
         .Build();
        var services = new ServiceCollection();


        services.AddDbContext<IronGridDbContext>(options =>
        options.UseMySql(
        configuration.GetConnectionString("testDb"),
        ServerVersion.AutoDetect(configuration.GetConnectionString("testDb"))));
        
services.AddScoped<EventProcessingService>();

        var serviceProvider = services.BuildServiceProvider();
        Console.WriteLine("Creating database...");
        using (var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<IronGridDbContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        Console.WriteLine(" Database ready\n");
    }
    var consumerConfig = new ConsumerConfig
    {
        BootstrapServers = configuration["Kafka:BootstrapServers"],
        GroupId = configuration["Kafka:GroupId"],
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false
    };