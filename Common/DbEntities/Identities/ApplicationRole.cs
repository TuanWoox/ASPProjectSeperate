using Common.DbEntities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DbEntities.Identities
{
    public class ApplicationRole:IdentityRole, IBaseKey<string>, IDeleted, ICreated, IModified
    {
        public string DisplayName { get; set; }

        public int Priority { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleCliams { get; set; }
        /// <summary>
        /// Implemented attributes of interfaces
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }
        [StringLength(255)]
        public string OwnerId { get; set; }

        public DateTimeOffset? DateModified { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTimeOffset DateDeleted { get; set; }
    }
}
