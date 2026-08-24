using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridConsumer.Models
{
    public class AssetsReading
    {
        public int AssetId { get; set; }
        public string AssetType { get; set; }
        public string RawValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
