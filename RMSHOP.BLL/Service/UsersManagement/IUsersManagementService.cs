
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
    }
}
