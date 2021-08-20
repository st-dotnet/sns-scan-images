using System;

namespace SNS.Services.DTOs
{
    public class ScanImageRequest
    { 
        public Guid Id { get; set; }
        public string Sku { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
