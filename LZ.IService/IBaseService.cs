using LZ.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// 通过id获取 用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<User> GetUserByID(long ID);
    }
}
