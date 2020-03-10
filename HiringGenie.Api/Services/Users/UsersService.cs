using HiringGenie.Api.Entities;
using HiringGenie.Api.Models.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly HiringGenieDbContext _context;

        public UsersService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            HiringGenieDbContext context,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task EditUser(UserDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            await AddUserToRolesAsync(user, model.Roles);
        }

        public async Task ForgotPassword(ForgotPasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = _userManager.GeneratePasswordResetTokenAsync(user);

            // send email with generate token and email
        }

        public IEnumerable<UserDTO> ListUsers()
        {
            return _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Select(c => new UserDTO 
                { Email = c.Email, Roles = c.UserRoles.Select(x => x.Role.Name) })
                .AsEnumerable();
        }

        public async Task<string> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return GenerateJwtToken(model.Email, appUser);
            }

            return string.Empty;
        }

        public async Task Register(UserDTO model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };

            var result = await _userManager.CreateAsync(user);
            await AddUserToRolesAsync(user, model.Roles);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (result.Succeeded && !string.IsNullOrEmpty(token))
            {
                //send email invite with token invite
                return;
            }

            // throw operation error
        }

        public async Task ChangePassword(ChangePasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

            if (!result.Succeeded)
            {
                // throw password error
            }
        }

        public async Task ResetPassword(ResetPasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ResetPasswordAsync(user, model.EmailToken, model.NewPassword);

            if (!result.Succeeded)
            {
                // throw password error
            }
        }

        private string GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task AddUserToRolesAsync(IdentityUser user, IEnumerable<string> roles)
        {
            await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
