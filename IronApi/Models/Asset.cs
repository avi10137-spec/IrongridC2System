using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class Asset
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int UnitId { get; set; }

        [Required]

        public string AssetSerial { get; set; } = string.Empty;
        public string? AssetType { get; set; } = "GenericAsset";



    }
}
