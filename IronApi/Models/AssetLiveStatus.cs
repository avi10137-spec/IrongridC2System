using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class AssetLiveInStatus
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        [AllowedValues("UAV", "PerimeterSensor")]
        public string AssetType { get; set; }
        [Required]
        public string RawValue { get; set; }
        [AllowedValues("Stable", "Warning")]
        public string ProcessedStatus { get; set; }
        [Required]
        public bool IsVerified { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}
