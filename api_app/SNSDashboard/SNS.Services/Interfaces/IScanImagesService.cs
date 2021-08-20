using SNS.Data.Entities;
using SNS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SNS.Services.Interfaces
{
    public interface IScanImagesService
    {
        Task<List<ScanImage>> Get();
        Task<bool> Create(ScanImageRequest request);
    }
}
