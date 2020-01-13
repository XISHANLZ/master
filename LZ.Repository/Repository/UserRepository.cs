

using LZ.IRepository.IRepository;
using LZ.Model.EntityContext;
using LZ.Model.Models;
using LZ.Model.Request;
using LZ.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Repository.Repository 
{
 
    public partial class UserRepository:LZRepository<User>, IUserRepository
    {
        public UserRepository()
        {

        }
        /// <summary>
        /// 通过条件获取用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<User> GetUserListByName(GetUserRequest request)
        {
            string sql = "select * from User where name="+request.UserName;
            using (var context = new EntityContext())
            {
                return  context.Database.SqlQuery<User>(sql);
            }
             

        }
    }
 
}
