using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models.ViewModel
{
    /// <summary>
    /// 分页数据集合
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PageData<TEntity>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        public List<TEntity> DataList { get; set; }
    }
     
}
