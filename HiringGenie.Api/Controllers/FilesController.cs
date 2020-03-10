using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringGenie.Api.Services.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HiringGenie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IUtilitiesService _utilitiesService;
        public FilesController(IUtilitiesService utilitiesService)
        {
            _utilitiesService = utilitiesService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            return Ok(await _utilitiesService.SaveFileAsync(file));
        }

        [HttpGet("{file}")]
        public async Task<IActionResult> GetFileAsync(string file)
        {
            var bytes = await _utilitiesService.GetFileBytesAsync(file);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(file, out string mimeType))
            {
                mimeType = "application/octet-stream";
            }
            Response.Headers.Add("Content-Disposition", "inline; filename=" + file);
            return File(bytes, mimeType);
        }
    }
}