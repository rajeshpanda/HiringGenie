using HiringGenie.Api.Models.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class Scheduler: BaseEntity
    {
        public DateTime ScheduledAt { get; set; }

        public SchedulerStatus SchedulerStatus { get; set; }

        public bool IsSlotMailSent { get; set; }

        public bool IsAcceptedMailSent { get; set; }

        public string Token { get; set; }

        public virtual Interview Interview { get; set; }
    }
}
