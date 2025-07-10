using Common.DbEntities.Identities;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext
     : IdentityDbContext<ApplicationUser, ApplicationRole, string,
                         ApplicationUserClaim, ApplicationUserRole,
                         ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<ApplicationPermission> ApplicationPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
