using Common.DbEntities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DbEntities.Identities
{
    public class ApplicationUser: IdentityUser, IBaseKey<string>, IDeleted, ICreated, IModified
    {
        [StringLength(255)]
        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public string? PictureURL { get; set; }

      
        public virtual ICollection<ApplicationUserClaim> UserClaims { get; set; }

        public virtual ICollection<ApplicationUserLogin> UserLogins { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
   
        public virtual ICollection<ApplicationUserToken> UserTokens { get; set; }

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
