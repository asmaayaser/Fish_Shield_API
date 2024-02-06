using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFileService
    {
        Task<string> uploadImage(string FolderNameStructureInWWWROOT, IFormFile Image, string ImageNewName);
        Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT, string DirName);
    }
}
