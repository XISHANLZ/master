﻿using LZ.IRepository.IRepository;
using LZ.IService;
using LZ.Model.Models;
using LZ.Model.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ.Service
{
    /// <summary>
    /// 基础服务
    /// 用户操作、权限操作、登陆操作
    /// </summary>
    public class BaseService : IBaseService
    {
        private readonly IUserRepository _userRepository;
        private ILogger<BaseService> logger;

        public BaseService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// 获取用户 用 框架获取的例子 
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            return _userRepository.GetAll(s => s.Id > 0).Take(100).ToList();
        }
        /// <summary>
        /// 获取用户 用sql 的例子
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserListByName(GetUserRequest request)
        {
            return _userRepository.GetUserListByName(request);
        }
        /// <summary>
        /// 通过id获取 用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<User> GetUserByID(long ID)
        {
            return await _userRepository.FirstOrDefaultAsync(s=>s.Id==ID);
        }
    }
}
