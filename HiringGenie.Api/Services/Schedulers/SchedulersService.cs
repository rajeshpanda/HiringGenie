using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using HiringGenie.Api.Models.Enums;
using HiringGenie.Api.Services.Interviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Schedulers
{
    public class SchedulersService : ISchedulersService
    {
        private HiringGenieDbContext _dbContext;
        private readonly IInterviewsService _interviewsService;

        public SchedulersService(HiringGenieDbContext context, IInterviewsService interviewsService)
        {
            _dbContext = context;
            _interviewsService = interviewsService;
        }

        public async Task<sbyte> AcceptAsync(Guid id, bool isAccept, string token)
        {
            var scheduler = await _dbContext.Schedulers.FirstOrDefaultAsync(c => c.Id == id && c.SchedulerStatus == SchedulerStatus.PLANNED && c.Token == token);
            var interview = await _interviewsService.GetInterviewBySchedulerIdAsync(id);

            if (scheduler != null && interview !=null)
            {
                if (isAccept)
                {
                    interview.IsInterviewScheduled = true;
                    scheduler.SchedulerStatus = SchedulerStatus.ACCEPTED;
                    //send email
                    return 1;
                } else
                {
                    interview.IsInterviewScheduled = false;
                    interview.SchedulerId = null;
                    scheduler.SchedulerStatus = SchedulerStatus.UNPLANNED;
                    // send email to schedule interview
                    return 0;
                }
            }

            return -1;
        }

        public async Task<Guid> ScheduleInterviewAsync(SchedulerDTO request)
        {
            var interview = await _interviewsService.GetInterviewByIdAsync(request.InterviewId);
            var scheduler = new Scheduler
            {
                Id = Guid.NewGuid(),
                SchedulerStatus = SchedulerStatus.PLANNED
            };

            interview.SchedulerId = scheduler.Id;
            await _dbContext.Schedulers.AddAsync(scheduler);
            await _dbContext.SaveChangesAsync();
            // send email to candidate
            var to_address = interview.Application.Email;

            return scheduler.Id;
        }
    }
}
