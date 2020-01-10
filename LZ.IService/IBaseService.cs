using LZ.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.IService
{
    /// <summary>
    /// 基础service
    /// </summary>
   public interface IBaseService
    {
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        List<User> GetUserList();
    }
}
