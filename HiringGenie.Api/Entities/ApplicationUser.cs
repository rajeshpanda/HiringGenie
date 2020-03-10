using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<Job> PostedJobs { get; set; }

        public virtual ICollection<Application> PostedApplications { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
