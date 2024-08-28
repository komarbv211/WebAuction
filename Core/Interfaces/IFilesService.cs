using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFilesService
    {
        Task<string> SaveLotImage(IFormFile file);
        Task DeleteLotImage(string path);
        Task<string> EditLotImage(string oldPath, IFormFile newFile);
    }
}
