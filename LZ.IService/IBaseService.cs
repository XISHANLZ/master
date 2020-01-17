using LZ.Model.Models;
using LZ.Model.Request;
using LZ.Model.Response;
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
        GetUserListResponse GetUserList(BasePageRequest request);

        /// <summary>
        /// 通过id获取 用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<User> GetUserByID(long ID);

        /// <summary>
        /// 删除 用户
        /// </summary>
        /// <param name="Id"></param>
        void DeleteUser(long Id);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<User> EditUser(EditUserRequest request);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        Task<User> CreateUser(User user);
    }
}
