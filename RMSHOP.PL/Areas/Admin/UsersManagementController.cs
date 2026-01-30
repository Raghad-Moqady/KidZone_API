using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSHOP.BLL.Service.UsersManagement;
using RMSHOP.DAL.DTO.Request.UserManagement;

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

        [HttpPatch("block_user/{userId}")]
        public async Task<IActionResult> BlockUser([FromRoute] string userId) =>
            Ok(await _usersManagementService.BlockUserAsync(userId));

        [HttpPatch("unblock_user/{userId}")]
        public async Task<IActionResult> UnBlockUser([FromRoute] string userId) =>
         Ok(await _usersManagementService.UnBlockUserAsync(userId));

        [Authorize(Roles = "SuperAdmin")]
        [HttpPatch("changeRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUserRoleRequest request)
        {
            var response = await _usersManagementService.ChangeUserRoleAsync(request);
            if (!response.Success)
            {
                if (response.Message.Contains("Not Found"))
                {
                    //404
                    return NotFound(response);
                }
                else
                {
                    //400
                    return BadRequest(response);
                }
            }
            //200
            return Ok(response);
        }
  

    }
}
