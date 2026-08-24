using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class AssetPutDto
    {
      
        
            public int UnitId { get; set; }

            [Required]

            public string AssetSerial { get; set; } = string.Empty;
            public string? AssetType { get; set; } = "GenericAsset";
        }
    
}
