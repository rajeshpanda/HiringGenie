using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Jobs
{
    public interface IJobsService
    {
        ICollection<Job> GetAllJobs(BaseRequestDTO request, string userId);

        Task<Job> GetJobByIdAsync(Guid id);

        Task<Guid> CreateJobAsync(Job job);

        Task<Guid> UpdateJobAsync(Guid id, Job job);

        Task<Guid> DeleteJobAsync(Guid id);
    }
}
