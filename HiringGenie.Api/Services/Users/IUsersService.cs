using HiringGenie.Api.Models.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Users
{
    public interface IUsersService
    {
        Task<string> Login(LoginDTO model);

        Task Register(UserDTO model);

        Task ForgotPassword(ForgotPasswordDTO model);

        Task ResetPassword(ResetPasswordDTO model);

        Task EditUser(UserDTO model);

        IEnumerable<UserDTO> ListUsers();
    }
}
