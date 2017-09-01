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
    public interface IRoleDao
    {
        void Add(Role role);
        bool Update(Role role);
        bool Delete(List<int> ids);
        ResultModel<Role> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        Role GetOne(int id);
        List<Role> Query(string exp, string orderExp, bool isDesc = true);
 
    }
}
