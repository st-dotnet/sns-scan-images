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
    public class DashboardController : Controller
    {
        private readonly IScanImagesService _scanImagesService;
        private readonly IMapper _mapper;

        public DashboardController(IScanImagesService scanImagesService, IMapper mapper)
        {
            _mapper = mapper;
            _scanImagesService = scanImagesService;
        }

        // GET: api/Products
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetScanImagesList()
        {
            try
            {
                var data = await _scanImagesService.Get();
                return Json(new { data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
