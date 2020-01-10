using System;
using System.Collections.Generic;

namespace LZ.Model.Models
{
    public partial class UserRoleRelation
    {
        public long Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
        public long? CreateUserId { get; set; }
    }
}
