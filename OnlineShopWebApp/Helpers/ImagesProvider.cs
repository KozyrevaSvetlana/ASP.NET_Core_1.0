using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;

        public ImagesProvider(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        public List<string> SafeFiles(IFormFile[] files, ImageFolders folder)
        {
            var imagesPaths = new List<string>();
            if (files !=null)
            {
                foreach (var file in files)
                {
                    var imagePath = SafeFile(file, folder);
                    imagesPaths.Add(imagePath);
                }
            }
            return imagesPaths;
        }

        public string SafeFile(IFormFile file, ImageFolders folder)
        {
            if (file != null)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/img/" + folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                string path = Path.Combine(folderPath, fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return "/img/" + folder + "/" + fileName;
            }
            return null;
        }
    }
}
