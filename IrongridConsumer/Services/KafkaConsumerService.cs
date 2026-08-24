using IrongridConsumer.Maping;
using IrongridConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace IrongridConsumer.Services
{
   /public class EventProcessingService
    {
        private readonly IronGridDbContext _dbContext;
        public EventProcessingService(IronGridDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ProcessAssestEventAsync(string jsonMessage)
        {
            try
            {

                var reading = JsonSerializer.Deserialize<AssetsReading>(jsonMessage);
                if (reading == null)
                {
                    Console.WriteLine(" Failed to deserialize Assets event");
                    return false;
                }

                if (!ValidateAssts(reading))
                {
                    Console.WriteLine($" Invalid assts event: {jsonMessage}");
                    return false;
                }
                bool exists = await _dbContext.AssetLiveStatus.AnyAsync(a => a.AssetId == reading.AssetId);
                if (exists)
                {
                    return true;
                }
                var AssetsLiveEvent = new AssetLiveInStatus
                {
                    AssetId = reading.AssetId,
                    AssetType = reading.AssetType,
                    RawValue = reading.RawValue,
                    ProcessedStatus = procceing(reading.RawValue),
                    IsVerified = isVerified(reading.RawValue),
                    LastUpdate = DateTime.UtcNow


                };
                _dbContext.AssetLiveStatus.Add(AssetsLiveEvent);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine($" Saved Asset event: {reading.AssetType}  ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" error processing event {ex.Message}");
                return false;
            }
        }









        //    public string procceing(string rawvalue)
        //{
        //    int newrawvalue;
        //    if(int.TryParse(rawvalue, out int newrawvalue);

            //    if (rawvalue >= 20 && rawvalue <= 100)
            //    {
            //        return "Stable";
            //    }
            //    if (rawvalue >= 0 && rawvalue <= 19)
            //    {
            //        return "Warning";
            //    }
            //    else { return "Warning"; }

            //}
        public bool isVerified(string rawvalue)
        {
            return false;
        }
    }
}
