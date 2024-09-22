using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.DTOs.Images;
using TTS.Entity.Enums;

namespace TTS.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string file, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete (string imageName);
    }
}
