using IronApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace IronApi.Models
{
    public class CriticalAssetDto
    {   
        public int Id { get; set; }
        public string AssetSerial { get; set; } = string.Empty;
        public string? AssetType { get; set; } = "GenericAsset";

        public string? UnitName { get; set; } = "Unknown Unit";
        public string? Sector { get; set; } = "General";
        public string ProcessedStatus { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }







    }
}
