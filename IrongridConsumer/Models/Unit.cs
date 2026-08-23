using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridConsumer.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string? UnitName { get; set; } = "Unknown Unit";
        public string? Sector { get; set; } = "General";
        
    }
}
