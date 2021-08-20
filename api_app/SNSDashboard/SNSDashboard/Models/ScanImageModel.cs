using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SNSDashboard.Models
{
    public class ScanImageModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Sku { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
