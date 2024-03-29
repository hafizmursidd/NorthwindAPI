﻿using Microsoft.AspNetCore.Http;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class UtilityServices : IUtilityService
    {
        public string UploadSingleFile(IFormFile formFile)
        {
            var fileName = string.Empty;
            try
            {
                var folderName = Path.Combine("Resources", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (formFile.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileName;
        }
    }
}
