using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs.User
{
    public class ChangePasswordDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
