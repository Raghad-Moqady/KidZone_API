using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.UserManagement
{
    public class ChangeUserRoleRequest
    {
        public string Id { get; set; }
        public List<string> NewRoles { get; set; }
    }
}
