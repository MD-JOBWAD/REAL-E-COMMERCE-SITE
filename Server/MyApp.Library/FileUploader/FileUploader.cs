using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyApp.Library
{
    class FileUploader
    {
        public static string Upload(IFormFile file, IHostingEnvironment hostingEnvironment)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadFolderPath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
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
