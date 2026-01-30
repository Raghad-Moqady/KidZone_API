using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RMSHOP.DAL.DTO.Request.UserManagement;
using RMSHOP.DAL.DTO.Response;
using RMSHOP.DAL.DTO.Response.UsersManagement;
using RMSHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.UsersManagement
{
    public class UsersManagementService : IUsersManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersManagementService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersResponse = users.Adapt<List<UserResponse>>();
            for (var i = 0;i< usersResponse.Count;i++)
            {
                var roles = await _userManager.GetRolesAsync(users[i]);
                usersResponse[i].Roles = roles.ToList();
            };
            return usersResponse;
        }

        public async Task<UserDetailsResponse> GetUserDetailsAsync(string userId)
        {
           var user = await _userManager.FindByIdAsync(userId);
           var userResponse = user.Adapt<UserDetailsResponse>();
           var roles= await _userManager.GetRolesAsync(user);
           userResponse.Roles = roles.ToList();
           return userResponse;
        }


        public async Task<BaseResponse> BlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEnabledAsync(user,true);
            await _userManager.SetLockoutEndDateAsync(user,DateTimeOffset.MaxValue);
            user.IsBlocked = true;
            await _userManager.UpdateAsync(user);
            return new BaseResponse()
            {
                 Success = true,
                 Message="User Blocked Successfully"
            };
        }
        public async Task<BaseResponse> UnBlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEnabledAsync(user, false);
            await _userManager.SetLockoutEndDateAsync(user, null);
            user.IsBlocked = false;
            await _userManager.UpdateAsync(user);
            return new BaseResponse()
            {
                Success = true,
                Message = "User UnBlocked Successfully"
            };
        }

        public async Task<BaseResponse> ChangeUserRoleAsync(ChangeUserRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
            {
                //404
                return new BaseResponse() { Success = false, Message = "User Not Found" };
            };
            string[] allowedRoles = ["SuperAdmin", "Admin", "User"];
            foreach (string newRole in request.NewRoles)
            {
                if (!allowedRoles.Contains(newRole)) 
                {
                    //400
                    return new BaseResponse() { Success = false, Message = $"Role '{newRole}' not valid!" };

                }
            }
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRolesAsync(user,request.NewRoles);
            //200
            return new BaseResponse() { Success = true, Message = "Roles Updated Successfully" };

        }
    }
}
