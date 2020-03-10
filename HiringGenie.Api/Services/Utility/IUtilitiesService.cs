using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Utility
{
    public interface IUtilitiesService
    {
        Task<string> SaveFileAsync(IFormFile file);

        string CreateToken();

        Task<byte[]> GetFileBytesAsync(string fileName);
    }
}
