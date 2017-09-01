using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Entity.CommonModel
{
    public class QueryBase
    {
        public string MenuId { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 开始记录数
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Draw { get; set; }
    }
}
