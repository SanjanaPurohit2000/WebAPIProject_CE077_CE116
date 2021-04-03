using GrowTogether.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Services
{
    public interface IFileService
    {
        public void SaveFile(List<IFormFile> files, string subDirectory);
        public (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory);
    }
}
