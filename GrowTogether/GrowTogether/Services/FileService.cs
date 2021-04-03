using GrowTogether.Models;
using GrowTogether.Services;
using GrowTogetherClient.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace GrowTogether.Controllers
{
    public class FileService : IFileService
    {
        GrowDbContext _context = null;
        public FileService(GrowDbContext context)
        {
            _context = context;
        }
        public (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(Material material)
        {
           
            try
            {
                Material m = new Material()
                {
                    Name = material.Name,
                    Path = material.Path
                };
                _context.Material.Add(m);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
