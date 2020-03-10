using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using HiringGenie.Api.Models.DTOs.Application;
using HiringGenie.Api.Services.Interviews;
using HiringGenie.Models.Enums;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Applications
{
    public class ApplicationsService : IApplicationsService
    {
        private HiringGenieDbContext _dbContext;
        private IInterviewsService _interviewsService;

        public ApplicationsService(HiringGenieDbContext context, IInterviewsService interviewsService)
        {
            _dbContext = context;
            _interviewsService = interviewsService;
        }

        public async Task<Guid> AssignInterviewAsync(AssignInterviewDTO request)
        {
            var application = await GetApplicationByIdAsync(request.ApplicationId);

            // create application
            if (request.IsInitialAssignment)
            {
                for (var i = 0; i < 3; i++)
                {
                    var interview = new Interview
                    {
                        ApplicationId = request.ApplicationId,
                        InterviewerId = request.Interviewers[i],
                        RoundNo = i + 1,
                        SchedulerId = null,
                        IsInterviewScheduled = false
                    };

                    await _interviewsService.CreateInterviewAsync(interview);
                }
            }

            return application.Id;
        }

        public async Task<Guid?> ChangeStatusAsync(Guid id, ApplicationStatus status, ApplicationStatus previousStatus)
        {
            var application = await GetApplicationByIdAsync(id);
            if (application.Status == previousStatus)
            {
                application.Status = status;
                await _dbContext.SaveChangesAsync();
                return application.Id;
            }

            return null;
        }

        public async Task<Guid> CreateApplicationAsync(Application application)
        {
            await _dbContext.Applications.AddAsync(application);
            await _dbContext.SaveChangesAsync();
            return application.Id;
        }

        public async Task<Guid> DeleteApplicationAsync(Guid id)
        {
            var application = await GetApplicationByIdAsync(id);
            application.IsWithdrawn = true;
            await _dbContext.SaveChangesAsync();

            return application.Id;
        }

        public async Task<Application> GetApplicationByIdAsync(Guid id)
        {
            return await _dbContext.Applications.FirstOrDefaultAsync(c => c.Id == id && !c.IsWithdrawn);
        }

        public ICollection<Application> GetAllApplications(GetObjectsByIdDTO request, string type, string userId = null)
        {
            var predicate = PredicateBuilder.New<Application>(true);
            if (!string.IsNullOrEmpty(request.Search))
            {
                predicate.And(c => c.Email.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.FirstName.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.LastName.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase)
                    || c.Phone.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(userId))
            {
                predicate.And(c => c.PostedBy == userId);
            }
            if (request.Id != null)
            {
                predicate.And(c => c.JobId == request.Id);
            }
            if (type == "new")
            {
                predicate.And(c => (int)c.Status <= 2);
            } 
            else if (type == "selected")
            {
                predicate.And(c => (int)c.Status > 2);
            }
            predicate.And(c => !c.IsWithdrawn);

            return _dbContext.Applications.Where(predicate.Compile()).Skip(request.Skip).Take(request.Take).ToList();
        }

        public async Task<Guid> ShortlistAsync(Guid id, bool isAdd)
        {
            var application = await GetApplicationByIdAsync(id);

            if (application.Status == ApplicationStatus.NEW && isAdd)
            {
                application.Status = ApplicationStatus.SHORTLISTED;
            }
            else if (application.Status == ApplicationStatus.SHORTLISTED && !isAdd)
            {
                application.Status = ApplicationStatus.NEW;
            }

            await _dbContext.SaveChangesAsync();

            return application.Id;
        }

        public Guid UpdateApplication(Guid id, Application application)
        {
            throw new NotImplementedException();
        }
    }
}
