using System;
using System.Collections.Generic;

namespace LZ.Model.Models
{
    public partial class LoginLog
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string LoginTime { get; set; }
    }
}
