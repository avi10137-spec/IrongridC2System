using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrongridProducer.Models
{
    public class assetslivestatus
    {
        public int AssetId { get; set; }
        public string AssetType { get; set; }
        public string RawValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
