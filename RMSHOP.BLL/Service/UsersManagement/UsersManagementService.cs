using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    }
}
