using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs.Application;
using HiringGenie.Api.Services.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiringGenie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsService _applicationsService;
        public ApplicationsController(IApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }

        [HttpGet]
        public ICollection<Application> Get([FromQuery] GetObjectsByIdDTO request, string type)
        {
            return _applicationsService.GetAllApplications(request, type, null);
        }

        [HttpPost]
        public async Task<Guid> PostAsync([FromBody] Application application)
        {
            return await _applicationsService.CreateApplicationAsync(application);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Application> GetAsync(Guid id)
        {
            return await _applicationsService.GetApplicationByIdAsync(id);
        }

        [HttpGet]
        [Route("shortlist/{id}")]
        public async Task<Guid> ShortlistAsync(Guid id, bool isAdd)
        {
            return await _applicationsService.ShortlistAsync(id, isAdd);
        }
    }
}