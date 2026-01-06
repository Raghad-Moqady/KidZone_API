using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service
{
    public class FileService : IFileService
    {
        // Upload the image to the Images folder and return the stored file name
        public async Task<string?> UploadAsync(IFormFile file)
        {
            if (file is not null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);//jsdhdiuahusa.pnj
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images", fileName);

                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;//to save it in DB
            }
            return null;
        }
    }
}
