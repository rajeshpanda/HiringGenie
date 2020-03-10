using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class Job: BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string SkillsRequired { get; set; }

        public int Positions { get; set; }

        [JsonIgnore]
        public bool PositionClosed { get; set; }

        public DateTime? DueDate { get; set; }

        public string PostedBy { get; set; }

        public string Compensation { get; set; }

        public string Experience { get; set; }

        public string Location { get; set; }

        public virtual ApplicationUser PostedByUser { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
