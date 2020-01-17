using common.Tools.Helper;
using LZ.IRepository.IRepository;
using LZ.IService;
using LZ.Model.Models;
using LZ.Model.Request;
using LZ.Model.Response;
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
        private ILogger<BaseService> _logger;

        public BaseService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// 获取用户 用 框架获取的例子 
        /// </summary>
        /// <returns></returns>
        public GetUserListResponse GetUserList(BasePageRequest request)
        {
            LogHelper.Info("获取用户");
            var userList = _userRepository.Where(s => s.Id > 0).OrderByDescending(s => s.CreateTime).Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);

            GetUserListResponse result = new GetUserListResponse();
            foreach (var item in userList)
            {
                //result.userListResponse.Add(new GetUserResponse()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    Account = item.Account,
                //    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                //    UpdateTime = item.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                //    PassWord = RSACryptionHelper.RSAEncrypt(item.PassWord),
                //});
                var model = new GetUserResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Account = item.Account,
                    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = item.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    //PassWord = RSACryptionHelper.RSADecrypt(item.PassWord),
                };
                result.userListResponse.Add(model);
            }
            return result;

        }
        /// <summary>
        /// 获取用户 用sql 的例子
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserListByName(GetUserRequest request)
        {
            LogHelper.Info("获取用户" + request.UserName);
            return _userRepository.GetUserListByName(request);

        }
        /// <summary>
        /// 通过id获取 用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<User> GetUserByID(long ID)
        {
            LogHelper.Info("获取用户" + ID);
            return await _userRepository.FirstOrDefaultAsync(s => s.Id == ID);
        }
        /// <summary>
        /// 删除 用户
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteUser(long Id)
        {
            LogHelper.Info("删除用户" + Id);
            _userRepository.Delete(s => s.Id == Id);
            _userRepository.SaveChangesAsync();
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<User> EditUser(EditUserRequest request)
        {
            LogHelper.Info("EditUser" + request.Id);
            var user = GetUserByID(request.Id).Result;
            if (user != null)
            {
                user.Name = request.Name;
                user.Account = request.Account;
                if (request.PassWord!= "******")
                {
                    user.PassWord = RSACryptionHelper.RSADecrypt(request.PassWord);
                }
                user.UpdateTime = DateTime.Now;
                 _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();
                return user;
            }
            else
            {
                return new User();
            }

        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        public async Task<User> CreateUser(User user)
        {
            try
            {
                user.PassWord = RSACryptionHelper.RSAEncrypt(user.PassWord); 
                await  _userRepository.InsertAsync(user);
                 _userRepository.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                var sss=ex.Message;
                throw;
            }
            
        }
    }
}
