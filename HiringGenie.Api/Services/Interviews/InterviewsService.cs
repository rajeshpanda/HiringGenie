using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Interviews
{
    public class InterviewsService : IInterviewsService
    {
        private HiringGenieDbContext _dbContext;

        public InterviewsService(HiringGenieDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> CreateInterviewAsync(Interview interview)
        {
            await _dbContext.Interviews.AddAsync(interview);
            await _dbContext.SaveChangesAsync();
            return interview.Id;
        }

        public async Task<Interview> GetInterviewByIdAsync(Guid id)
        {
            return await _dbContext.Interviews.Include(c => c.Application).FirstOrDefaultAsync(c => c.Id == id);
        }

        public ICollection<Interview> GetAllMyInterviewByStatusAsync(string userId, InterviewStatus status)
        {
            return _dbContext.Interviews.Include(c => c.Application)
                .Where(c => c.InterviewStatus == status && c.InterviewerId == userId).ToList();
        }

        public async Task<Interview> GetInterviewBySchedulerIdAsync(Guid id)
        {
            return await _dbContext.Interviews.Include(c => c.Application).FirstOrDefaultAsync(c => c.SchedulerId == id);
        }
    }
}
