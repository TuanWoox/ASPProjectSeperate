using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DbEntities.BaseEntities
  
{
    public interface IBaseKey<TKey>
    {
        public TKey Id { get; set; }
    }
    public class BaseKey: IBaseKey<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
    public class BaseEntity<TKey> : IBaseKey<TKey>, IDeleted, ICreated, IModified       
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        [StringLength(255)]
        public string OwnerId { get; set; }

        public DateTimeOffset? DateModified { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTimeOffset DateDeleted { get; set; }
    }
    public interface IDeleted
    {
        public bool IsDeleted { get; set; }

        public DateTimeOffset DateDeleted { get; set; }
    }
    public interface ICreated 
    {
        public DateTimeOffset? DateCreated { get;set; }
        [StringLength(255)]
        public string OwnerId { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
    public interface IModified
    {
        public DateTimeOffset? DateModified { get; set; }
    }
}
