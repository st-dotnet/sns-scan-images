using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using SNS.Services.DTOs;
using SNS.Services.Interfaces;
using SNSDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace SNSDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageDataController : ControllerBase
    {
        private readonly IScanImagesService _scanImagesService;
        private readonly IMapper _mapper;

        public ImageDataController(IScanImagesService scanImagesService, IMapper mapper)
        {
            _mapper = mapper;
            _scanImagesService = scanImagesService;
        }


        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create(ScanImageModel model)
        {
            try
            {
                if (!ModelState.IsValid) return Ok(new { error = "Data is not valid." });

                var data = _mapper.Map<ScanImageRequest>(model);
                var result = await _scanImagesService.Create(data);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
