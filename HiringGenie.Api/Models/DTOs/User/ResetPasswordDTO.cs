using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Models.DTOs.User
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }

        public string EmailToken { get; set; }

        public string NewPassword { get; set; }
    }
}
