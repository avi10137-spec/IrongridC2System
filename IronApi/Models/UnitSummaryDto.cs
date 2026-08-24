using System.Text.RegularExpressions;

namespace IronApi.Models
{
    public class UnitSummaryDto
    {
       public int Id { get; set; }
        public string? UnitName { get; set; } = "Unknown Unit";
        public string? Sector { get; set; } = "General";
        public int TotalAssets { get; set; }
        public int StableAssets { get; set; }
        public int WarningAssets { get; set; }
        public int UnverifiedAssets { get; set; }
    }
}

