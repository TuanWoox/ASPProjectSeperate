using Common.Interfaces;
using Common.Utils.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Business
{
    public class RoleBusiness: IRoleBusiness
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleBusiness(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task InitRole()
        {
            var defaultRoles = Enum.GetNames(typeof(RoleEnum)).ToList();
            foreach (var defaultRole in defaultRoles)
            {
                var isRoleCreated = await _roleManager.RoleExistsAsync(defaultRole);
                if (!isRoleCreated)
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = defaultRole });
                }
            }
        }
    }
}
