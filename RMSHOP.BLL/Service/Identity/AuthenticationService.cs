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

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            //request >> Email & Password
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null) {
                    //400
                    return new LoginResponse()
                    {
                        Success = false,
                        Message = "Invalid Email !",
                    };
                }
                var result = await _userManager.CheckPasswordAsync(user, request.Password);
                if(!result)
                {
                    //400
                    return new LoginResponse()
                    {
                        Success = false,
                        Message = "Invalid Password !",
                    };
                }
                //200
                return new LoginResponse()
                {
                    Success = true,
                    Message = "Login Successfully",
                };
            }
            catch (Exception ex) {
                //500
                return new LoginResponse()
                {
                    Success = false,
                    UnexpectedErrorFlag = true,
                    Message = "An Unexpected error !",
                    Errors = new List<string> { ex.Message }
                };
            
            }
        }

        //Domain Model is >> ApplicationUser:IdentityUser
        //DTO >> RegisterRequest
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var user = request.Adapt<ApplicationUser>();
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    //400
                    return new RegisterResponse()
                    {
                        Success = false,
                        Message = "User Creation Failed",
                        Errors = result.Errors.Select(e => e.Description).ToList()
                    };
                }
                await _userManager.AddToRoleAsync(user, "User");
                //200
                return new RegisterResponse()
                {
                    Success = true,
                    Message = "Success"
                };


            }
            catch (Exception ex) {
                //500
                return new RegisterResponse()
                {
                    Success = false,
                    UnexpectedErrorFlag=true,
                    Message = "An Unexpected error !",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
