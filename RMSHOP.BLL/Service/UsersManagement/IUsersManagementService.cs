
using RMSHOP.DAL.DTO.Request.UserManagement;
using RMSHOP.DAL.DTO.Response;
using RMSHOP.DAL.DTO.Response.UsersManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.UsersManagement
{
    public interface IUsersManagementService
    {
        Task<List<UserResponse>> GetAllUsersAsync();
        Task<UserDetailsResponse> GetUserDetailsAsync(string userId);
        Task<BaseResponse> BlockUserAsync(string userId);
        Task<BaseResponse> UnBlockUserAsync(string userId);
        Task<BaseResponse> ChangeUserRoleAsync(ChangeUserRoleRequest request);
    }
}
