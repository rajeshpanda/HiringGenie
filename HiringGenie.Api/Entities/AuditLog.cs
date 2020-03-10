using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string KeyValues { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

        public string CreatedBy { get; set; }
    }
}
