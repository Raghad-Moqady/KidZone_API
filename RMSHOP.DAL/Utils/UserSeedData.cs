using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RMSHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Utils
{
    public class UserSeedData : ISeedData
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserSeedData(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task DataSeed()
        {
            if(! await _userManager.Users.AnyAsync())
            {
                ApplicationUser[] users = [
                    new ApplicationUser{
                          UserName="RMoqady",
                          Email="raghad@gmail.com",
                          FullName="Raghad Emad Moqady",
                          EmailConfirmed=true,
                    },
                    new ApplicationUser{
                          UserName="TMoqady",
                          Email="tala@gmail.com",
                          FullName="tala Moqady",
                          EmailConfirmed=true,
                    },
                    new ApplicationUser{
                          UserName="WMoqady",
                          Email="waseem@gmail.com",
                          FullName="Waseem Moqady",
                          EmailConfirmed=true,
                    }
                    ];
                string[] passwords = ["Pass@1122", "Pass@1122", "Pass@1122"];
                
                string[] roles = ["SuperAdmin", "Admin", "User"];

                for (int i = 0; i < users.Length; i++) { 
                  await _userManager.CreateAsync(users[i], passwords[i]);
                  await _userManager.AddToRoleAsync(users[i], roles[i]);
                }
            }
            
        }
    }
}
