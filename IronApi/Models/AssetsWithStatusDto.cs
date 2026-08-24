using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class AssetsWithStatusDto
    {
        public int UnitId { get; set; }
        public int AssetId { get; set; }
       
        public string? AssetType { get; set; } = "GenericAsset";
        [Required]
        public string RawValue { get; set; }
        [AllowedValues("Stable", "Warning")]
        public string ProcessedStatus { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public string AssetSerial { get; set; } = string.Empty;
      

    }
}
