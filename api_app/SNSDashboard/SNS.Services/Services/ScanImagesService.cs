using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SNS.Data.DbContexts;
using SNS.Data.Entities;
using SNS.Data.Utilities;
using SNS.Services.DTOs;
using SNS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNS.Services.Services
{
    public class ScanImagesService : IScanImagesService
    {

        private readonly ScanImagesContext _scanImagesContext;
        private readonly IMapper _mapper;
        private IHostingEnvironment _hostEnvironment;
        private readonly Settings _settings;

        public ScanImagesService(ScanImagesContext scanImagesContext, IHostingEnvironment hostEnvironment, Settings settings, IMapper mapper)
        {
            _mapper = mapper;
            _scanImagesContext = scanImagesContext;
            _hostEnvironment = hostEnvironment;
            _settings = settings;
        }

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Create(ScanImageRequest request)
        {
            try
            {
                request.Images = LoadImage(request.Images);
                var data = _mapper.Map<ScanImage>(request);
                _scanImagesContext.ScanImages.Add(data);
                await _scanImagesContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ScanImage>> Get()
        {
            try
            {
                var list = await _scanImagesContext.ScanImages.OrderBy(x => x.CreatedOn).ToListAsync();
                list.AddRange(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region Public Methods

        private string LoadImage(string image)
        {
            try
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, _settings.ImagePath);
                byte[] bytes = Convert.FromBase64String(image);
                var fileName = $"{Guid.NewGuid()}.jpg";
                string filePath = Path.Combine(uploadsFolder, fileName);
                File.WriteAllBytes(filePath, bytes);
                return fileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
