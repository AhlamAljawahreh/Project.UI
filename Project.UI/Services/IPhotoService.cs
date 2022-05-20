using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddItemPhotoAsync(IBrowserFile File);
    }
}
