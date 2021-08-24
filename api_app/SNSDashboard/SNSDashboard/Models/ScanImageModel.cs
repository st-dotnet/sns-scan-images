using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SNSDashboard.Models
{
    public class ScanImageModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Images { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
