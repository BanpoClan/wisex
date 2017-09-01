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
    public interface IMenuDao
    {
        void Add(Menu menu);
        bool Update(Menu menu);
        bool Delete(List<int> ids);
        ResultModel<Menu> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        Menu GetOne(Hashtable param);
        List<Menu> Query(string exp, string orderExp, bool isDesc = true);

    }
}
