using System.ComponentModel.DataAnnotations;

namespace IronApi.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string? UnitName { get; set; } = "Unknown Unit";
        public string? Sector { get; set; } = "General";

    }
}
