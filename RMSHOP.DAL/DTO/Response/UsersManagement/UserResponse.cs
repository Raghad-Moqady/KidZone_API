using RMSHOP.DAL.Models.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Response.UsersManagement
{
    public class UserResponse
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; }= null!;
        public string Email { get; set; } = null!;
        public bool IsBlocked {  get; set; }
        public List<string> Roles { get; set; } = new List<string>();
         
      }
}
