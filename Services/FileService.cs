using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class IOService : IIOService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public IOService(IWebHostEnvironment webHostEnvironment)
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

        public async Task<bool> DeleteDirectory(string directoryName)
        {

            var path = $"{webHostEnvironment.WebRootPath}/images/detects/";
            var old = $"{path}{directoryName}";
            var @new = $"{path}{directoryName}[deleted]";
            try
            {
                Directory.Move(old,@new);
            }
            catch
            {
                return false;
            }
            return true ;
        }

        public async Task<bool> DeleteFile(string filename, string filePathWithExtension)
        {
            var ext=  Path.GetExtension(filePathWithExtension);

            var path = $"{webHostEnvironment.WebRootPath}/images/Personal/";
            var old = $"{path}{filename}{ext}";
            
            var @new = $"{path}{filename}[deleted]{ext}";

         
            try {
                File.Move(old,@new);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
