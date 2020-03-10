using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Utility
{
    public class UtilitiesService : IUtilitiesService
    {
        public string CreateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/files/{fileName}";
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }

            return null;
        }

        public async Task<byte[]> GetFileBytesAsync(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath =  $"{AppDomain.CurrentDomain.BaseDirectory}/files/{fileName}";
                return await File.ReadAllBytesAsync(filePath);
            }

            return null;
        }
    }
}
