using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Jobs
{
    public class JobsService : IJobsService
    {
        private HiringGenieDbContext _dbContext;

        public JobsService(HiringGenieDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> CreateJobAsync(Job job)
        {
            await _dbContext.Jobs.AddAsync(job);
            await _dbContext.SaveChangesAsync();
            return job.Id;
        }

        public async Task<Guid> DeleteJobAsync(Guid id)
        {
            var job = await GetJobByIdAsync(id);
            job.PositionClosed = true;
            await _dbContext.SaveChangesAsync();

            return job.Id;
        }

        public ICollection<Job> GetAllJobs(BaseRequestDTO request, string userId)
        {
            var predicate = PredicateBuilder.New<Job>(true);
            if (!string.IsNullOrEmpty(request.Search))
            {
                predicate.And(c => c.Location.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.SkillsRequired.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.Description.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.Title.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(userId))
            {
                predicate.And(c => c.PostedBy == userId);
            }
            predicate.And(c => !c.PositionClosed);

            return _dbContext.Jobs.Where(predicate.Compile()).Skip(request.Skip).Take(request.Take).ToList();
        }

        public async Task<Job> GetJobByIdAsync(Guid id)
        {
            return await _dbContext.Jobs.FirstOrDefaultAsync(c => c.Id == id && !c.PositionClosed);
        }

        public async Task<Guid> UpdateJobAsync(Guid id, Job job)
        {
            var record = await GetJobByIdAsync(id);
            record.Description = job.Description;
            record.Compensation = job.Compensation;
            record.Experience = job.Experience;
            record.Location = job.Location;
            record.Positions = job.Positions;
            record.SkillsRequired = job.SkillsRequired;
            record.Title = job.Title;
            await _dbContext.SaveChangesAsync();

            return record.Id;
        }
    }
}
