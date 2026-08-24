using IronApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace IronApi.Models
{
    public class AssetStatusDto
    {
       
        public int AssetId { get; set; }

        public string? AssetType { get; set; } = "GenericAsset";
        [Required]
       
        [AllowedValues("Stable", "Warning")]
        public string ProcessedStatus { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public string AssetSerial { get; set; } = string.Empty;
    }
}
