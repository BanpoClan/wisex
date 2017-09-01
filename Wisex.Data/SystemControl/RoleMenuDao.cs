using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public class RoleMenuDao : BaseDao, IRoleMenuDao
    {
        public List<RoleMenu> Query(string exp, string orderExp, bool isDesc = true)
        {
            return base.GetDataList<RoleMenu>(exp, orderExp, isDesc);
        }
    }
}
