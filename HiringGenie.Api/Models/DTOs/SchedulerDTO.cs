using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs
{
    public class SchedulerDTO
    {
        public Guid InterviewId { get; set; }

        public DateTime ScheduledAt { get; set; }
    }
}
