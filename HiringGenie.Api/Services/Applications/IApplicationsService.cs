using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using HiringGenie.Api.Models.DTOs.Application;
using HiringGenie.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Applications
{
    public interface IApplicationsService
    {
        ICollection<Application> GetAllApplications(GetObjectsByIdDTO request, string type, string userId = null);

        Task<Application> GetApplicationByIdAsync(Guid id);

        Task<Guid> CreateApplicationAsync(Application application);

        Guid UpdateApplication(Guid id, Application application);

        Task<Guid> DeleteApplicationAsync(Guid id);

        Task<Guid?> ChangeStatusAsync(Guid id, ApplicationStatus status, ApplicationStatus previousStatus);

        Task<Guid> ShortlistAsync(Guid id, bool isAdd);

        Task<Guid> AssignInterviewAsync(AssignInterviewDTO request);
    }
}
