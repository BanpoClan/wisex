using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public class PageViewDao : BaseDao,IPageViewDao
    {
        public bool Add(PageView dto)
        {
            //执行SQL：获取表对应的字段，用当前对象的字段构造insert语句，再执行插入
            base.Add("CreatePageView", dto);
            return true;
        }
    }
}
