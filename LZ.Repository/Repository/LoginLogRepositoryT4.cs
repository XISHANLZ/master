

using LZ.IRepository.IRepository;
using LZ.Model.Models;
using LZ.Repository;

namespace Interfaces.Repository.Repository 
{
 
    public partial class LoginLogRepository:LZRepository<LoginLog>, ILoginLogRepository
    {
       
    }
 
}
