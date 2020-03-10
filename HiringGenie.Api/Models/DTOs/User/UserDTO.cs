using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs.User
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string Phone { get; set; }

        // enable in V2
        // public bool IsLockedOut { get; set; }
    }
}
