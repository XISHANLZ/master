using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Model.Request
{
    /// <summary>
    /// 修改用户请求参数
    /// </summary>
    public class EditUserRequest
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

    }
}
