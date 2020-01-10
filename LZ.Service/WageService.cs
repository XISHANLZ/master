using LZ.IRepository.IRepository;
using LZ.IService;
using LZ.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ.Service
{
    public class WageService : IWageService
    {
        private readonly IWageRepository _wageRepository;
        public WageService(IWageRepository wageRepository)
        {
            _wageRepository = wageRepository;
        }
        /// <summary>
        /// 获取工资信息
        /// </summary>
        /// <returns></returns>
        public List<Wage> GetWageList()
        {
            return _wageRepository.GetAll(s=>s.Id>0).Take(100).ToList();
        }
        /// <summary>
        /// 异步获取第一个工资条
        /// </summary>
        /// <returns></returns>
        public async Task<Wage> GetFirstWage()
        {
            return await _wageRepository.FirstOrDefaultAsync(s=>s.Id==1);
        }
    }
}
