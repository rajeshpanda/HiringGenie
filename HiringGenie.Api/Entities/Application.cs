using HiringGenie.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class Application: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ResumePath { get; set; }

        public string DisplayPicture { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PostedBy { get; set; }

        public ApplicationUser PostedByUser { get; set; }

        public ApplicationStatus Status { get; set; }

        public bool IsInviteSent { get; set; }

        public Guid JobId { get; set; }

        [JsonIgnore]
        public bool IsWithdrawn { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }

        public virtual Job Job { get; set; }
    }
}
