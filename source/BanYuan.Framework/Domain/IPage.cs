using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework.Domain
{
    public interface IPage
    {
        /// <summary>
        /// 总行数
        /// </summary>
        int TotalRecord { get; }
        /// <summary>
        /// 行数
        /// </summary>
        int RowCount { get; }
        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 当前页
        /// </summary>
        int CurrentPage { get; }
    }
}
