using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Schedulers
{
    public interface ISchedulersService
    {
        Task<Guid> ScheduleInterviewAsync(SchedulerDTO request);

        Task<sbyte> AcceptAsync(Guid id, bool isAccept, string token);
    }
}
