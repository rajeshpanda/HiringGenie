using HiringGenie.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Interviews
{
    public interface IInterviewsService
    {
        Task<Guid> CreateInterviewAsync(Interview interview);

        Task<Interview> GetInterviewByIdAsync(Guid id);

        Task<Interview> GetInterviewBySchedulerIdAsync(Guid id);
    }
}
