using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork
{
    public interface IImageProcessing
    {
        public string GetImagePath(string fileName, string parentFolderName);
        public string GetImagePathForDb(string imagePath);
    }
}
