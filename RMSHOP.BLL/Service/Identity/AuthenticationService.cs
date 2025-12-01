using Mapster;
using Microsoft.AspNetCore.Identity;
using RMSHOP.DAL.DTO.Request;
using RMSHOP.DAL.DTO.Response;
using RMSHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //Domain Model is >> ApplicationUser:IdentityUser
        //DTO >> RegisterRequest
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
             var user= request.Adapt<ApplicationUser>();
             var result= await _userManager.CreateAsync(user, request.Password);
             await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded) 
            {
                return new RegisterResponse()
                {
                    Message = "Error"
                };
            }
            return new RegisterResponse()
            {
                Message = "Success"
            };
             

        }
    }
}
