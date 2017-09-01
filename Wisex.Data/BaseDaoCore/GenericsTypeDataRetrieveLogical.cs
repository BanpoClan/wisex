using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;

namespace Wisex.Dao.BaseDaoCore
{
    /// <summary>
    /// 泛型类型数据检索逻辑
    /// </summary>
    public class GenericsTypeDataRetrieveLogical : DataRetrieveLogical
    {
        public GenericsTypeDataRetrieveLogical(string tableMame, string likeQueryStr, QueryBase queryBase) : base(tableMame, likeQueryStr, queryBase) { }
    }
}
