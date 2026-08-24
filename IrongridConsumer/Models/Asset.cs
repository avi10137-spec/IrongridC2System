using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridConsumer.Models
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
