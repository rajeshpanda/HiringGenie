using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs.Application
{
    public class GetObjectsByIdDTO: BaseRequestDTO
    {
        public Guid? Id { get; set; }
    }
}
