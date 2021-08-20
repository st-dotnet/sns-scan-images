using AutoMapper;
using SNS.Data.Entities;
using SNS.Services.DTOs;
using SNSDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSDashboard.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ScanImageRequest, ScanImageModel>().ReverseMap();
            CreateMap<ScanImage, ScanImageRequest>().ReverseMap();
        }
    }
}
