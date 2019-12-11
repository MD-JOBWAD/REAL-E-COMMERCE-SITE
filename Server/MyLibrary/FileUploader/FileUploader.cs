using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.FileUploader
{
    public static class FileUploader
    {
        public static string Upload(IFormFile file, IHostingEnvironment hostingEnvironment)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadFolderPath = Path.Combine(hostingEnvironment.WebRootPath, "Images/Products");
                uniqueFileName = file.FileName; //not a unique name
                string uploaddFile = Path.Combine(uploadFolderPath, uniqueFileName);
                using (FileStream fileStream = new FileStream(uploaddFile, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
