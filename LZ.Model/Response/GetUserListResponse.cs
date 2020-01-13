using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Model.Response
{
    /// <summary>
    /// 获取用户列表返回实体
    /// </summary>
    public class GetUserListResponse
    {
        public GetUserListResponse()
        {
            userListResponse = new List<GetUserResponse>();
        }
        public List<GetUserResponse> userListResponse { get; set; }

    }
    public class GetUserResponse
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 姓名
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
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string UpdateTime { get; set; }
    }
}
