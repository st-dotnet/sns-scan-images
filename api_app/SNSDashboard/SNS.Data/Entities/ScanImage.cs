using System;
using System.ComponentModel.DataAnnotations;

namespace SNS.Data.Entities
{
    public class ScanImage
    {
        [Key]
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
