using LZ.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LZ.IService
{
    /// <summary>
    /// 工资服务
    /// </summary>
    public interface IWageService
    {
        /// <summary>
        /// 获取所有工资
        /// </summary>
        /// <returns></returns>
        List<Wage> GetWageList();
        /// <summary>
        /// 异步获取第一个工资条
        /// </summary>
        /// <returns></returns>
        Task<Wage> GetFirstWage();
    }
}
