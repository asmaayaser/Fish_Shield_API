using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> uploadImage(string FolderNameStructureInWWWROOT, IFormFile Image, string ImageNewName)
        {
            var Extension = Path.GetExtension(Image.FileName);
            var path = $"{webHostEnvironment.WebRootPath}/{FolderNameStructureInWWWROOT}/{ImageNewName}{Extension}";

            using (var stream = File.Create(path))
            {
                await Image.CopyToAsync(stream);
                await stream.FlushAsync();
            }
            return $"/{FolderNameStructureInWWWROOT}/{ImageNewName}{Extension}";
        }

        public async Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT,string DirName)
        {
            string path = $"{webHostEnvironment.WebRootPath}/{FolderNameStructureInWWWROOT}/{DirName}";
            try
            {
                Directory.CreateDirectory(path);
            } catch { 
                return false ;
            }
            return true ;
        }
    }
}
