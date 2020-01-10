using System;
using System.Collections.Generic;

namespace LZ.Model.Models
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public long CreateUserId { get; set; }
        public string CreateUserName { get; set; }
    }
}
