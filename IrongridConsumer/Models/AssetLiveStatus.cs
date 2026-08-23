using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridConsumer.Models
{
    public class AssetLiveStatus
    {
        [Key]
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
