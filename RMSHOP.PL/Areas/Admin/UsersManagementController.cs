using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSHOP.BLL.Service.UsersManagement;

namespace RMSHOP.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class UsersManagementController : ControllerBase
    {
        private readonly IUsersManagementService _usersManagementService;

        public UsersManagementController(IUsersManagementService usersManagementService)
        {
            _usersManagementService = usersManagementService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()=>
            Ok(await _usersManagementService.GetAllUsersAsync());

        [HttpGet("user/{userId}/details")]
        public async Task<IActionResult> GetUserDetails([FromRoute] string userId)=>
            Ok(await _usersManagementService.GetUserDetailsAsync(userId));
        


    }
}
