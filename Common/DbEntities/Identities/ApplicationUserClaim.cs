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
    public class ApplicationUserClaim: IdentityUserClaim<string>, IDeleted
    {
        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTimeOffset DateDeleted { get; set; }
    }
}
