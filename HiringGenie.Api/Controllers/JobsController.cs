using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using HiringGenie.Api.Services.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiringGenie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public ICollection<Job> Get([FromQuery] BaseRequestDTO request)
        {
            return _jobsService.GetAllJobs(request, null);
        }

        // GET: api/Jobs
        [HttpGet]
        [Route("my-jobs")]
        public ICollection<Job> GetMyJobs([FromQuery] BaseRequestDTO request)
        {
            return _jobsService.GetAllJobs(request, null);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Job> GetAsync(Guid id)
        {
            return await _jobsService.GetJobByIdAsync(id);
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<Guid> PostAsync([FromBody] Job job)
        {
            return await _jobsService.CreateJobAsync(job);
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<Guid> PutAsync(Guid id, [FromBody] Job job)
        {
            return await _jobsService.UpdateJobAsync(id, job);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Guid> DeleteAsync(Guid id)
        {
            return await _jobsService.DeleteJobAsync(id);
        }
    }
}
