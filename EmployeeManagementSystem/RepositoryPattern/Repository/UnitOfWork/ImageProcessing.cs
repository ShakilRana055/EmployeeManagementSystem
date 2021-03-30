using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.UnitOfWork
{
    public class ImageProcessing : IImageProcessing
    {
        private IWebHostEnvironment _environment;
        public ImageProcessing(IWebHostEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        public string GetUniqueImageName(string imagePrefix, IFormFile photo)
        {
            var fileName = ContentDispositionHeaderValue.Parse(photo.ContentDisposition).FileName.Trim('"').Replace(" ", string.Empty);
            List<string> separate = fileName.Split(".").ToList();
            fileName = imagePrefix + DateTime.Now.ToString("dddd_dd_MMMM_yyyy_HH_mm_ss") + "." + separate[1];
            return fileName;
        }
        public string GetImagePath(string fileName, string folderName)
        {
            string path = _environment.WebRootPath + "\\" + "images" + "\\" + folderName + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }

        public string GetImagePathForDb(string imagePath)
        {
            string webRootFolder = _environment.WebRootPath;
            imagePath = imagePath.Replace(webRootFolder, "");
            imagePath = imagePath.Replace(@"\", "/");
            return imagePath;
        }
        
    }
}
