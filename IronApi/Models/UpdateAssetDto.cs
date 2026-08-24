using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class UpdateAssetDto
    {
        public int UnitId { get; set; }

        [Required]

        public string AssetSerial { get; set; } = string.Empty;
        public string? AssetType { get; set; } = "GenericAsset";

    }
}
