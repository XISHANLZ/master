
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LZ.IRepository;
using LZ.Model.Models;
using LZ.Model.Request;

namespace LZ.IRepository.IRepository 
{
 
    public partial interface IUserRepository:ILZRepository<User>
    {
        /// <summary>
        /// 通过条件获取用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<User> GetUserListByName(GetUserRequest request);
    }
 
}
