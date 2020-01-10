using System;
using System.Collections.Generic;

namespace LZ.Model.Models
{
    public partial class LoginInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserRole { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
