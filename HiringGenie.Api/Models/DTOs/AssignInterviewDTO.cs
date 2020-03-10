using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs
{
    public class AssignInterviewDTO
    {
        public Guid ApplicationId { get; set; }

        public string[] Interviewers { get; set; }

        public bool IsInitialAssignment { get; set; }
    }
}
