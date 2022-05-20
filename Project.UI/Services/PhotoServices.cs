using Abp.Domain.Uow;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Project.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService( IOptions<CloudinarySettings> config)
        {
 
            var acc = new Account
            (
                "aaaaahlllaaaam",
                "193885872152754",
                "f3kI9RfUXvoF_NoE9ho2YFYaH2A"
            );
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddItemPhotoAsync(IBrowserFile File)
        {
            var uploadResult = new ImageUploadResult();

                Console.WriteLine("hii");
                var  stream = File.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(File.Name, stream),
                   
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            
            return uploadResult;
        }


    }
}
