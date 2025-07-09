using Common.Interfaces;
using Common.Utils.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class UserBusiness: IUserBusiness
    {
        UserManager<IdentityUser> _userManager;
        public UserBusiness(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task InitUser()
        {
            
            string password = "P@ssword123!";

            for (int i = 1; i < 10; i++)
            {
                string username = $"User1Nom{i}";

                var user = new IdentityUser
                {
                    UserName = username,
                    Email = username + "@gmail.com"
                };
                var isUserCreated = await _userManager.FindByNameAsync(user.UserName);
                if (isUserCreated == null)
                {
                    var result = await _userManager.CreateAsync(user, password);

                    {
                        if (result.Succeeded && i == 1)
                        {
                            await _userManager.AddToRoleAsync(user, RoleEnum.Admin.ToString());
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());
                        }
                    }
                }   
            }
        }
    }
}
