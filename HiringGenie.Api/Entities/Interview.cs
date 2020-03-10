using HiringGenie.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class Interview : BaseEntity
    {
        public int RoundNo { get; set; }

        public string Notes { get; set; }

        public bool IsComplete { get; set; }

        public InterviewStatus InterviewStatus { get; set; }

        public bool IsInterviewScheduled { get; set; }

        public string AlternateCareerNotes { get; set; }

        public Guid ApplicationId { get; set; }

        public Guid? SchedulerId { get; set; }

        public string InterviewerId { get; set; }

        public string RecordedAudioPath { get; set; }

        public virtual ApplicationUser Interviewer { get; set; }

        public virtual Application Application { get; set; }

        public virtual Scheduler CurrentScheduler { get; set; }
    }
}
